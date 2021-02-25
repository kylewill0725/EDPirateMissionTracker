using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class InterdictedEvent : EventBase
    {
        internal InterdictedEvent()
        {
        }

        [JsonProperty("Submitted")] public bool Submitted { get; private set; }

        [JsonProperty("Interdictor")] public string Interdictor { get; private set; }

        [JsonProperty("IsPlayer")] public bool IsPlayer { get; private set; }

        [JsonProperty("Faction")] public string Faction { get; private set; }
    }

    public partial class InterdictedEvent
    {
        public static InterdictedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<InterdictedEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<InterdictedEvent> InterdictedEvent;

    }
}