using System;
using System;
using System.Collections.Generic;
using System.Globalization;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace EliteSharp.Event.Models
{
    public partial class CarrierDepositFuelEvent : EventBase
    {
        internal CarrierDepositFuelEvent() { }

        [JsonProperty("CarrierID")]
        public long CarrierId { get; private set; }

        [JsonProperty("Amount")]
        public long Amount { get; private set; }

        [JsonProperty("Total")]
        public long Total { get; private set; }
    }

    public partial class CarrierDepositFuelEvent
    {
        public static CarrierDepositFuelEvent FromJson(string json) => JsonConvert.DeserializeObject<CarrierDepositFuelEvent>(json);
    }

    public partial interface IEventHandler
    {
        public event EventHandler<CarrierDepositFuelEvent> CarrierDepositFuelEvent;
    }
}