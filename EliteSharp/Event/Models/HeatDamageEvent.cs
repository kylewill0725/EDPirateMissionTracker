using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class HeatDamageEvent : EventBase
    {
        internal HeatDamageEvent()
        {
        }

        [JsonProperty("event")] public string Event { get; private set; }
    }

    public partial class HeatDamageEvent
    {
        public static HeatDamageEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<HeatDamageEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<HeatDamageEvent> HeatDamageEvent;

    }
}