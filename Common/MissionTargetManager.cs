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
        private readonly Dictionary<string, SortedList<string, Mission>> _factionMissions;
        private readonly Dictionary<string, Mission> _indexedMissions;
        private readonly SourceCache<Mission, string> _missionCache = new(m => m.MissionId);
        private readonly ConcurrentDictionary<string, Mission> _concurrentDict = new();

        public MissionTargetManager(IEliteDangerousApi api)
        {
            _factionMissions = new Dictionary<string, SortedList<string, Mission>>();
            _indexedMissions = new Dictionary<string, Mission>();

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
                            IsWing = e.Wing
                        };
                        return mission;
                    }).Where(m => m.TargetType == "$MissionUtil_FactionTag_Pirate;")
                    .Do(m => _concurrentDict.TryAdd(m.MissionId, m));

            var redirected =
                apiEvents.MissionRedirectedEvent.Merge(MissionRedirected)
                    .Where(e => _concurrentDict.ContainsKey(e.MissionId))
                    .Select(e =>
                    {
                        var mission = _concurrentDict[e.MissionId];
                        mission.CurrentKills = mission.TotalKills;
                        mission.IsFilled = true;
                        return mission;
                    });
            
            var completed = 
                apiEvents.MissionCompletedEvent.Merge(MissionCompleted)
                    .Where(e => _concurrentDict.ContainsKey(e.MissionId))
                    .Select(e =>
                    {
                        // _concurrentDict.TryGetValue(e.MissionId, out var mission);
                        _concurrentDict.Remove(e.MissionId, out var mission);
                        mission!.IsComplete = true;
                        return mission;
                    });
            
            var failed =
                apiEvents.MissionFailedEvent.Merge(MissionFailed).Select(e => e.MissionId)
                    .Merge(
                        apiEvents.MissionAbandonedEvent.Merge(MissionAbandoned)
                            .Select(e => e.MissionId)
                        )
                    .Where(id => _concurrentDict.ContainsKey(id))
                    .Select(id =>
                    {
                        // _concurrentDict.TryGetValue(id, out var mission);
                        _concurrentDict.Remove(id, out var mission);
                        mission!.IsFailed = true;
                        return mission;
                    });

            completed
                .Merge(failed)
                .Subscribe(mission => _missionCache.RemoveKey(mission.MissionId));
            
            // Emits on every change. Should be a hot observable
            IObservable<Mission> missions = acceptedPirateMissions
                .Merge(redirected);
            _missionCache.PopulateFrom(missions);
        }

        // Used for catching up
        public Subject<MissionAcceptedEvent> MissionAccepted { get; } = new();
        public Subject<MissionRedirectedEvent> MissionRedirected { get; } = new();
        public Subject<MissionFailedEvent> MissionFailed { get; } = new();
        public Subject<MissionAbandonedEvent> MissionAbandoned { get; } = new();
        public Subject<MissionCompletedEvent> MissionCompleted { get; } = new();
        public Subject<BountyEvent> Bounty { get; } = new();
    }
    
    
    [DebuggerDisplay("{Faction} - {CurrentKills}/{TotalKills}")]
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

        public override string ToString()
        {
            return $"{Faction} - {CurrentKills}/{TotalKills} - {Started} - {Expiry}";
        }
    }
}