using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class MarketSellEvent : EventBase
    {
        internal MarketSellEvent()
        {
        }

        [JsonProperty("MarketID")] public long MarketId { get; private set; }

        [JsonProperty("Type")] public string Type { get; private set; }

        [JsonProperty("Type_Localised")] public string TypeLocalised { get; private set; }

        [JsonProperty("Count")] public long Count { get; private set; }

        [JsonProperty("SellPrice")] public long SellPrice { get; private set; }

        [JsonProperty("TotalSale")] public long TotalSale { get; private set; }

        [JsonProperty("AvgPricePaid")] public long AvgPricePaid { get; private set; }
    }

    public partial class MarketSellEvent
    {
        public static MarketSellEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MarketSellEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<MarketSellEvent> MarketSellEvent;

    }
}