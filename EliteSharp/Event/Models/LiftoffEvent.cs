using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class LiftoffEvent : EventBase
    {
        internal LiftoffEvent()
        {
        }

        [JsonProperty("PlayerControlled")] public bool PlayerControlled { get; private set; }

        [JsonProperty("Latitude")] public double Latitude { get; private set; }

        [JsonProperty("Longitude")] public double Longitude { get; private set; }
    }

    public partial class LiftoffEvent
    {
        public static LiftoffEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<LiftoffEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<LiftoffEvent> LiftoffEvent;

    }
}