using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class PayLegacyFinesEvent : EventBase
    {
        internal PayLegacyFinesEvent()
        {
        }

        [JsonProperty("Amount")] public long Amount { get; private set; }

        [JsonProperty("BrokerPercentage")] public double BrokerPercentage { get; private set; }
    }

    public partial class PayLegacyFinesEvent
    {
        public static PayLegacyFinesEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PayLegacyFinesEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<PayLegacyFinesEvent> PayLegacyFinesEvent;

    }
}