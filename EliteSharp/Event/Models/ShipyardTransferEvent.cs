using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class ShipyardTransferEvent : EventBase
    {
        internal ShipyardTransferEvent()
        {
        }

        [JsonProperty("ShipType")] public string ShipType { get; private set; }

        [JsonProperty("ShipType_Localised")] public string ShipTypeLocalised { get; private set; }

        [JsonProperty("ShipID")] public long ShipId { get; private set; }

        [JsonProperty("System")] public string System { get; private set; }

        [JsonProperty("ShipMarketID")] public long ShipMarketId { get; private set; }

        [JsonProperty("Distance")] public double Distance { get; private set; }

        [JsonProperty("TransferPrice")] public long TransferPrice { get; private set; }

        [JsonProperty("TransferTime")] public long TransferTime { get; private set; }

        [JsonProperty("MarketID")] public long MarketId { get; private set; }
    }

    public partial class ShipyardTransferEvent
    {
        public static ShipyardTransferEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ShipyardTransferEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<ShipyardTransferEvent> ShipyardTransferEvent;

    }
}