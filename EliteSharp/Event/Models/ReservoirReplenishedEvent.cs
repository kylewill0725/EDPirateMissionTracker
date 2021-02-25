using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class ReservoirReplenishedEvent : EventBase
    {
        internal ReservoirReplenishedEvent()
        {
        }

        [JsonProperty("FuelMain")] public double FuelMain { get; private set; }

        [JsonProperty("FuelReservoir")] public double FuelReservoir { get; private set; }
    }

    public partial class ReservoirReplenishedEvent
    {
        public static ReservoirReplenishedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ReservoirReplenishedEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<ReservoirReplenishedEvent> ReservoirReplenishedEvent;

    }
}