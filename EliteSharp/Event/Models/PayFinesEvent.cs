using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class PayFinesEvent : EventBase
    {
        internal PayFinesEvent()
        {
        }

        [JsonProperty("Amount")] public long Amount { get; private set; }

        [JsonProperty("AllFines")] public bool AllFines { get; private set; }

        [JsonProperty("Faction")] public string Faction { get; private set; }

        [JsonProperty("ShipID")] public long ShipId { get; private set; }
    }

    public partial class PayFinesEvent
    {
        public static PayFinesEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PayFinesEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<PayFinesEvent> PayFinesEvent;

    }
}