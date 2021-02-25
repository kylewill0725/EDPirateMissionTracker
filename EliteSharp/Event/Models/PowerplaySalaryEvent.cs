using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class PowerplaySalaryEvent : EventBase
    {
        internal PowerplaySalaryEvent()
        {
        }

        [JsonProperty("Power")] public string Power { get; private set; }

        [JsonProperty("Amount")] public long Amount { get; private set; }
    }

    public partial class PowerplaySalaryEvent
    {
        public static PowerplaySalaryEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PowerplaySalaryEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<PowerplaySalaryEvent> PowerplaySalaryEvent;

    }
}