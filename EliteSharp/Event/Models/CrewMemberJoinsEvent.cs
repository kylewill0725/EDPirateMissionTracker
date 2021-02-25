using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class CrewMemberJoinsEvent : EventBase
    {
        internal CrewMemberJoinsEvent()
        {
        }

        [JsonProperty("Crew")] public string Crew { get; private set; }
    }

    public partial class CrewMemberJoinsEvent
    {
        public static CrewMemberJoinsEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CrewMemberJoinsEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<CrewMemberJoinsEvent> CrewMemberJoinsEvent;

    }
}