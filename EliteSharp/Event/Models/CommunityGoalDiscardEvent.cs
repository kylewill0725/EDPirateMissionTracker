using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class CommunityGoalDiscardEvent : EventBase
    {
        internal CommunityGoalDiscardEvent()
        {
        }

        [JsonProperty("Name")] public string Name { get; private set; }

        [JsonProperty("System")] public string System { get; private set; }
    }

    public partial class CommunityGoalDiscardEvent
    {
        public static CommunityGoalDiscardEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CommunityGoalDiscardEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<CommunityGoalDiscardEvent> CommunityGoalDiscardEvent;

    }
}