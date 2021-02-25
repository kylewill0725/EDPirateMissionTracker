using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class ShipyardSwapEvent : EventBase
    {
        internal ShipyardSwapEvent()
        {
        }

        [JsonProperty("ShipType")] public string ShipType { get; private set; }

        [JsonProperty("ShipType_Localised")] public string ShipTypeLocalised { get; private set; }

        [JsonProperty("ShipID")] public long ShipId { get; private set; }

        [JsonProperty("StoreOldShip")] public string StoreOldShip { get; private set; }

        [JsonProperty("StoreShipID")] public long StoreShipId { get; private set; }

        [JsonProperty("MarketID")] public long MarketId { get; private set; }
    }

    public partial class ShipyardSwapEvent
    {
        public static ShipyardSwapEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ShipyardSwapEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<ShipyardSwapEvent> ShipyardSwapEvent;

    }
}