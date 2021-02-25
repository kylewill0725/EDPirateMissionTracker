using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class CommunityGoalRewardEvent : EventBase
    {
        internal CommunityGoalRewardEvent()
        {
        }

        [JsonProperty("Name")] public string Name { get; private set; }

        [JsonProperty("System")] public string System { get; private set; }

        [JsonProperty("Reward")] public long Reward { get; private set; }
    }

    public partial class CommunityGoalRewardEvent
    {
        public static CommunityGoalRewardEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CommunityGoalRewardEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<CommunityGoalRewardEvent> CommunityGoalRewardEvent;

    }
}