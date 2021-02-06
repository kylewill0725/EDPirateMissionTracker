using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using EliteAPI.Event.Models;
using EliteAPI.Event.Models.Abstractions;
using EliteAPI.Event.Provider.Abstractions;
using EliteAPI.Journal.Directory.Abstractions;
using Newtonsoft.Json.Linq;
// ReSharper disable PossibleMultipleEnumeration

namespace Common
{
    /// <summary>
    /// 
    /// </summary>
    public class MissionCatchUp
    {
        private readonly IJournalReader _journalReader;
        private readonly MissionTargetManager _missionTargetManager;
        private Subject<MissionAcceptedEvent> _missionAcceptedEvents = new();

        public MissionCatchUp(IJournalReader journalReader, MissionTargetManager missionTargetManager)
        {
            _journalReader = journalReader;
            _missionTargetManager = missionTargetManager;
        }

        public void CatchUp()
        {
            Console.WriteLine("Catching up");
            foreach (var evt in GetRecentMissionEvents())
            {
                switch (evt)
                {
                    case MissionAcceptedEvent ma:
                        _missionTargetManager.MissionAccepted.OnNext(ma);
                        break;
                    case MissionRedirectedEvent mredirect:
                        _missionTargetManager.MissionRedirected.OnNext(mredirect);
                        break;
                    case MissionFailedEvent mfailed:
                        _missionTargetManager.MissionFailed.OnNext(mfailed);
                        break;
                    case MissionAbandonedEvent mabandon:
                        _missionTargetManager.MissionAbandoned.OnNext(mabandon);
                        break;
                    case MissionCompletedEvent mcomplete:
                        _missionTargetManager.MissionCompleted.OnNext(mcomplete);
                        break;
                    case BountyEvent bounty:
                        _missionTargetManager.Bounty.OnNext(bounty);
                        break;
                    case LocationEvent location:
                        _missionTargetManager.Location.OnNext(location);
                        break;
                    case DockedEvent docked:
                        _missionTargetManager.Docked.OnNext(docked);
                        break;
                }
            }
            
            _missionTargetManager.MissionAccepted.OnCompleted();
            _missionTargetManager.MissionRedirected.OnCompleted();
            _missionTargetManager.MissionFailed.OnCompleted();
            _missionTargetManager.MissionAbandoned.OnCompleted();
            _missionTargetManager.MissionCompleted.OnCompleted();
            _missionTargetManager.Bounty.OnCompleted();
            _missionTargetManager.Location.OnCompleted();
        }

        private IEnumerable<EventBase> GetRecentMissionEvents()
        {
            var allMissions = GetInterestingEvents().ReadEventsSince(DateTime.MinValue);
            var unaccountedForMissions = new HashSet<string>();
            var events = _journalReader.TypeOf<MissionsEvent>().TypeOf<MissionAcceptedEvent>().ReadEvents();
            var missions = events.OfType<MissionsEvent>().FirstOrDefault();
            do
            {
                if (missions == null)
                {
                    return allMissions;
                }

                if (!missions.Active.Any())
                {
                    return GetInterestingEvents().ReadEventsSince(missions.Timestamp);
                }

                foreach (var missionId in missions.Active.Cast<JObject>()
                    .Select(jo => jo["MissionID"]!.Value<string>()))
                {
                    unaccountedForMissions.Add(missionId);
                }

                missions = events.OfType<MissionsEvent>().FirstOrDefault();
            } while (missions != null);

            throw new Exception("Coudln't find empty missions thing");
        }

        public IJournalReadBuilder GetInterestingEvents()
        {
            return _journalReader
                .TypeOf<MissionAcceptedEvent>()
                .TypeOf<MissionAbandonedEvent>()
                .TypeOf<MissionCompletedEvent>()
                .TypeOf<MissionRedirectedEvent>()
                .TypeOf<MissionFailedEvent>()
                .TypeOf<LocationEvent>()
                .TypeOf<DockedEvent>()
                .TypeOf<BountyEvent>();

        }
    }
}