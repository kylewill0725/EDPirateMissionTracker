using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class CommunityGoalJoinEvent : EventBase
    {
        internal CommunityGoalJoinEvent()
        {
        }

        [JsonProperty("Name")] public string Name { get; private set; }

        [JsonProperty("System")] public string System { get; private set; }
    }

    public partial class CommunityGoalJoinEvent
    {
        public static CommunityGoalJoinEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CommunityGoalJoinEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<CommunityGoalJoinEvent> CommunityGoalJoinEvent;

    }
}