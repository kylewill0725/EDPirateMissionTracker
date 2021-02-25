using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class DatalinkVoucherEvent : EventBase
    {
        internal DatalinkVoucherEvent()
        {
        }

        [JsonProperty("Reward")] public long Reward { get; private set; }

        [JsonProperty("VictimFaction")] public string VictimFaction { get; private set; }

        [JsonProperty("PayeeFaction")] public string PayeeFaction { get; private set; }
    }

    public partial class DatalinkVoucherEvent
    {
        public static DatalinkVoucherEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<DatalinkVoucherEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<DatalinkVoucherEvent> DatalinkVoucherEvent;

    }
}