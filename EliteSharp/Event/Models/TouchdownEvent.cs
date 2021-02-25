using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class TouchdownEvent : EventBase
    {
        internal TouchdownEvent()
        {
        }

        [JsonProperty("PlayerControlled")] public bool PlayerControlled { get; private set; }

        [JsonProperty("Latitude")] public double Latitude { get; private set; }

        [JsonProperty("Longitude")] public double Longitude { get; private set; }
    }

    public partial class TouchdownEvent
    {
        public static TouchdownEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<TouchdownEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<TouchdownEvent> TouchdownEvent;

    }
}