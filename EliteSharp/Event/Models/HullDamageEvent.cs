using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class HullDamageEvent : EventBase
    {
        internal HullDamageEvent()
        {
        }

        [JsonProperty("Health")] public double Health { get; private set; }

        [JsonProperty("PlayerPilot")] public bool PlayerPilot { get; private set; }

        [JsonProperty("Fighter")] public bool Fighter { get; private set; }
    }

    public partial class HullDamageEvent
    {
        public static HullDamageEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<HullDamageEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<HullDamageEvent> HullDamageEvent;

    }
}