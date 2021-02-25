using System;
using System.Collections.Generic;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class CommunityGoalEvent : EventBase
    {
        internal CommunityGoalEvent()
        {
        }

        [JsonProperty("CurrentGoalInfos")] public IReadOnlyList<CurrentGoalInfo> CurrentGoalInfos { get; private set; }


        public class CurrentGoalInfo
        {
            internal CurrentGoalInfo()
            {
            }

            [JsonProperty("CGID")] public long Cgid { get; private set; }

            [JsonProperty("Title")] public string Title { get; private set; }

            [JsonProperty("SystemName")] public string SystemName { get; private set; }

            [JsonProperty("MarketName")] public string MarketName { get; private set; }

            [JsonProperty("Expiry")] public DateTimeOffset Expiry { get; private set; }

            [JsonProperty("IsComplete")] public bool IsComplete { get; private set; }

            [JsonProperty("CurrentTotal")] public long CurrentTotal { get; private set; }

            [JsonProperty("PlayerContribution")] public long PlayerContribution { get; private set; }

            [JsonProperty("NumContributors")] public long NumContributors { get; private set; }

            [JsonProperty("TopTierInfo")] public TopTierInfo TopTier { get; private set; }

            [JsonProperty("TierReached")] public string TierReached { get; private set; }

            [JsonProperty("PlayerPercentileBand")] public long PlayerPercentileBand { get; private set; }

            [JsonProperty("Bonus")] public long Bonus { get; private set; }
        }

        public class TopTierInfo
        {
            internal TopTierInfo()
            {
            }

            [JsonProperty("Name")] public string Name { get; private set; }

            [JsonProperty("Bonus")] public string Bonus { get; private set; }
        }
    }

    public partial class CommunityGoalEvent
    {
        public static CommunityGoalEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CommunityGoalEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<CommunityGoalEvent> CommunityGoalEvent;

    }
}