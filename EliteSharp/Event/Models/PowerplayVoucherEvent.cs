using System;
using System.Collections.Generic;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class PowerplayVoucherEvent : EventBase
    {
        internal PowerplayVoucherEvent()
        {
        }

        [JsonProperty("Power")] public string Power { get; private set; }

        [JsonProperty("Systems")] public IReadOnlyList<string> Systems { get; private set; }
    }

    public partial class PowerplayVoucherEvent
    {
        public static PowerplayVoucherEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PowerplayVoucherEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<PowerplayVoucherEvent> PowerplayVoucherEvent;

    }
}