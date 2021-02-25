using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class RepairDroneEvent : EventBase
    {
        internal RepairDroneEvent()
        {
        }

        [JsonProperty("HullRepaired")] public double HullRepaired { get; private set; }
    }

    public partial class RepairDroneEvent
    {
        public static RepairDroneEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<RepairDroneEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<RepairDroneEvent> RepairDroneEvent;

    }
}