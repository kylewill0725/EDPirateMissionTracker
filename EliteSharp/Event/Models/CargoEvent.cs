using System;
using System.Collections.Generic;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class CargoEvent : EventBase
    {
        internal CargoEvent()
        {
        }

        [JsonProperty("Vessel")] public string Vessel { get; private set; }

        [JsonProperty("Count")] public long Count { get; private set; }

        [JsonProperty("Inventory")] public IReadOnlyList<object> Inventory { get; private set; }
    }

    public partial class CargoEvent
    {
        public static CargoEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CargoEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<CargoEvent> CargoEvent;

    }
}