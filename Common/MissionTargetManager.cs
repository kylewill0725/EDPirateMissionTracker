using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using DynamicData;
using DynamicData.Kernel;
using EliteAPI.Abstractions;
using EliteAPI.Event.Attributes;
using EliteAPI.Event.Handler;
using EliteAPI.Event.Models;
using EliteAPI.Event.Module;
using Newtonsoft.Json.Linq;

namespace Common
{
    public class MissionTargetManager
    {
        private readonly SourceCache<Mission, string> _missionCache = new(m => m.MissionId);
        public IObservable<IChangeSet<Mission, string>> Connect() => _missionCache.Connect();
        private readonly ConcurrentDictionary<string, Mission> _missions = new();
        private readonly ConcurrentDictionary<string, SortedList<string, Mission>> _factions = new();
        private string _station = "";
        private string _system = "";

        public MissionTargetManager(IEliteDangerousApi api)
        {
            var apiEvents = api.Events.Events();

            var acceptedPirateMissions =
                apiEvents.MissionAcceptedEvent.Merge(MissionAccepted)
                    .Where(m => m.Name.ToLower().Contains("massacre"))
                    .Select(e =>
                    {
                        var jo = JObject.Parse(e.Json);
                        var mission = new Mission
                        {
                            MissionId = e.MissionId,
                            Expiry = e.Expiry,
                            Started = e.Timestamp,
                            Faction = e.Faction,
                            TargetFaction = e.TargetFaction,
                            TotalKills = jo["KillCount"]!.Value<int>(),
                            TargetType = e.TargetType,
                            IsWing = e.Wing,
                            Station = _station,
                            Reward = e.Reward,
                            Title = e.LocalisedName,
                            System = _system
                        };
                        return mission;
                    }).Where(m => m.TargetType == "$MissionUtil_FactionTag_Pirate;")
                    .Do(m => _missions.TryAdd(m.MissionId, m))
                    .Do(m =>
                    {
                        if (!_factions.TryGetValue(m.Faction, out var missions))
                        {
                            missions = new SortedList<string, Mission>();
                            _factions.TryAdd(m.Faction, missions);
                        }

                        missions.Add(m.MissionId, m);
                    });

            apiEvents.DockedEvent.Merge(Docked)
                .Select(d => new StationInfo(d.StarSystem, d.StationName))
                .Merge(apiEvents.LocationEvent.Merge(Location).Where(l => l.Docked)
                    .Select(l => new StationInfo(l.StarSystem, l.StationName)))
                .Subscribe(station =>
                {
                    _station = station.Station;
                    _system = station.System;
                });

            var redirected =
                apiEvents.MissionRedirectedEvent.Merge(MissionRedirected)
                    .Where(e => _missions.ContainsKey(e.MissionId))
                    .Select(e =>
                    {
                        var mission = _missions[e.MissionId];
                        
                        // mission.CurrentKills = mission.TotalKills;
                        
                        if (_factions.TryGetValue(mission.Faction, out var missions))
                        {
                            missions.Remove(mission.MissionId);
                        }
                        
                        mission.IsFilled = true;
                        return mission;
                    });

            var completed =
                apiEvents.MissionCompletedEvent.Merge(MissionCompleted)
                    .Where(e => _missions.ContainsKey(e.MissionId))
                    .Select(e =>
                    {
                        // _missions.Remove(e.MissionId, out var mission);
                        _missions.TryGetValue(e.MissionId, out var mission);
                        
                        if (_factions.TryGetValue(mission!.Faction, out var missions))
                        {
                            missions.Remove(mission.MissionId);
                        }
                        
                        mission!.IsComplete = true;
                        return mission;
                    });

            var failed =
                apiEvents.MissionFailedEvent.Merge(MissionFailed).Select(e => e.MissionId)
                    .Merge(
                        apiEvents.MissionAbandonedEvent.Merge(MissionAbandoned)
                            .Select(e => e.MissionId)
                    )
                    .Where(id => _missions.ContainsKey(id))
                    .Select(id =>
                    {
                        // _missions.Remove(id, out var mission);
                        _missions.TryGetValue(id, out var mission);
                        
                        if (_factions.TryGetValue(mission!.Faction, out var missions))
                        {
                            missions.Remove(id);
                        }
                        
                        mission!.IsFailed = true;
                        return mission;
                    });

            var bountyUpdates =
                Bounty.Merge(apiEvents.BountyEvent)
                    .SelectMany(b =>
                    {
                        return _factions
                            .Where(pair => pair.Value.Count > 0 
                                           && pair.Value.First().Value.TargetFaction == b.VictimFaction)
                            .Select(pair =>
                            {
                                var mission = pair.Value.First().Value;
                                if (mission.TargetFaction != b.VictimFaction)
                                    throw new Exception("Mission should have existed");

                                mission.CurrentKills += 1;
                                return mission;
                            });
                    });

            completed
                .Merge(failed)
                .Subscribe(mission => _missionCache.RemoveKey(mission.MissionId));

            // Emits on every change. Should be a hot observable
            IObservable<Mission> missions =
                acceptedPirateMissions
                    .Merge(bountyUpdates)
                    .Merge(redirected);
            _missionCache.PopulateFrom(missions);
        }

        // Used for catching up
        public Subject<MissionAcceptedEvent> MissionAccepted { get; } = new();
        public Subject<MissionRedirectedEvent> MissionRedirected { get; } = new();
        public Subject<MissionFailedEvent> MissionFailed { get; } = new();
        public Subject<MissionAbandonedEvent> MissionAbandoned { get; } = new();
        public Subject<MissionCompletedEvent> MissionCompleted { get; } = new();
        public Subject<LocationEvent> Location { get; } = new();
        public Subject<DockedEvent> Docked { get; } = new();
        public Subject<BountyEvent> Bounty { get; } = new();
    }

    public record StationInfo(string System, string Station);

    [DebuggerDisplay("{Faction} - {CurrentKills}/{TotalKills} - Filled {IsFilled} - Success {IsComplete} - Fail {IsFailed}")]
    public class Mission
    {
        public string MissionId { get; init; }
        public DateTime Started { get; init; }
        public DateTime Expiry { get; set; }
        public bool IsWing { get; init; }
        public bool IsComplete { get; set; }
        public bool IsFailed { get; set; }
        public string Faction { get; init; }
        public string TargetFaction { get; init; }
        public int CurrentKills { get; set; }
        public int TotalKills { get; init; }
        public string TargetType { get; init; }
        public bool IsFilled { get; set; }
        public string Station { get; init; }
        public long Reward { get; init; }
        public string Title { get; init; }
        public string System { get; init; }

        public override string ToString()
        {
            return $"{Faction} - {CurrentKills}/{TotalKills} - {Started} - {Expiry}";
        }
    }
}