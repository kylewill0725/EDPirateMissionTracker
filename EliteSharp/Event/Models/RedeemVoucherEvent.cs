using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class RedeemVoucherEvent : EventBase
    {
        internal RedeemVoucherEvent()
        {
        }

        [JsonProperty("Type")] public string Type { get; private set; }

        [JsonProperty("Amount")] public long Amount { get; private set; }

        [JsonProperty("Faction")] public string Faction { get; private set; }
    }

    public partial class RedeemVoucherEvent
    {
        public static RedeemVoucherEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<RedeemVoucherEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<RedeemVoucherEvent> RedeemVoucherEvent;

    }
}