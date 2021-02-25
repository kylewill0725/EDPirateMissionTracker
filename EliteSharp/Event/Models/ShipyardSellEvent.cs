using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class ShipyardSellEvent : EventBase
    {
        internal ShipyardSellEvent()
        {
        }

        [JsonProperty("ShipType")] public string ShipType { get; private set; }

        [JsonProperty("SellShipID")] public long SellShipId { get; private set; }

        [JsonProperty("ShipPrice")] public long ShipPrice { get; private set; }

        [JsonProperty("System")] public string System { get; private set; }
    }

    public partial class ShipyardSellEvent
    {
        public static ShipyardSellEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ShipyardSellEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<ShipyardSellEvent> ShipyardSellEvent;

    }
}