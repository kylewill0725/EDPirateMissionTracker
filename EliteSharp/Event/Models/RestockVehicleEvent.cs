using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class RestockVehicleEvent : EventBase
    {
        internal RestockVehicleEvent()
        {
        }

        [JsonProperty("Type")] public string Type { get; private set; }

        [JsonProperty("Loadout")] public string Loadout { get; private set; }

        [JsonProperty("Cost")] public long Cost { get; private set; }

        [JsonProperty("Count")] public long Count { get; private set; }
    }

    public partial class RestockVehicleEvent
    {
        public static RestockVehicleEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<RestockVehicleEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<RestockVehicleEvent> RestockVehicleEvent;

    }
}