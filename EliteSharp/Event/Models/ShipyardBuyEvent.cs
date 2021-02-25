using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class ShipyardBuyEvent : EventBase
    {
        internal ShipyardBuyEvent()
        {
        }

        [JsonProperty("ShipType")] public string ShipType { get; private set; }

        [JsonProperty("ShipType_Localised")] public string ShipTypeLocalised { get; private set; }

        [JsonProperty("ShipPrice")] public long ShipPrice { get; private set; }

        [JsonProperty("StoreOldShip")] public string StoreOldShip { get; private set; }

        [JsonProperty("StoreShipID")] public long StoreShipId { get; private set; }

        [JsonProperty("MarketID")] public long MarketId { get; private set; }
    }

    public partial class ShipyardBuyEvent
    {
        public static ShipyardBuyEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ShipyardBuyEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<ShipyardBuyEvent> ShipyardBuyEvent;

    }
}