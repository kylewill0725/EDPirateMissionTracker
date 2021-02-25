using System;
using System;
using System.Collections.Generic;
using System.Globalization;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EliteSharp.Event.Models
{
    public partial class CarrierJumpCancelledEvent : EventBase
    {
        internal CarrierJumpCancelledEvent() { }

        [JsonProperty("CarrierID")]
        public long CarrierId { get; private set; }
    }

    public partial class CarrierJumpCancelledEvent
    {
        public static CarrierJumpCancelledEvent FromJson(string json) => JsonConvert.DeserializeObject<CarrierJumpCancelledEvent>(json);
    }

    public partial interface IEventHandler
    {
        public event EventHandler<CarrierJumpCancelledEvent> CarrierJumpCancelledEvent;
    }
}