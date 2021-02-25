using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class VehicleSwitchEvent : EventBase
    {
        internal VehicleSwitchEvent()
        {
        }

        [JsonProperty("event")] public string Event { get; private set; }
    }

    public partial class VehicleSwitchEvent
    {
        public static VehicleSwitchEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<VehicleSwitchEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<VehicleSwitchEvent> VehicleSwitchEvent;

    }
}