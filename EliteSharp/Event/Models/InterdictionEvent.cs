using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class InterdictionEvent : EventBase
    {
        internal InterdictionEvent()
        {
        }

        [JsonProperty("Success")] public bool Success { get; private set; }

        [JsonProperty("IsPlayer")] public bool IsPlayer { get; private set; }

        [JsonProperty("Faction")] public string Faction { get; private set; }
    }

    public partial class InterdictionEvent
    {
        public static InterdictionEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<InterdictionEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<InterdictionEvent> InterdictionEvent;

    }
}