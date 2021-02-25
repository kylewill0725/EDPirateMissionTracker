using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class CrewMemberQuitsEvent : EventBase
    {
        internal CrewMemberQuitsEvent()
        {
        }

        [JsonProperty("Crew")] public string Crew { get; private set; }
    }

    public partial class CrewMemberQuitsEvent
    {
        public static CrewMemberQuitsEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CrewMemberQuitsEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<CrewMemberQuitsEvent> CrewMemberQuitsEvent;

    }
}