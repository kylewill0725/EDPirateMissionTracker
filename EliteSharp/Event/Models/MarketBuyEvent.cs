using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class MarketBuyEvent : EventBase
    {
        internal MarketBuyEvent()
        {
        }

        [JsonProperty("Type")] public string Type { get; private set; }

        [JsonProperty("Count")] public long Count { get; private set; }

        [JsonProperty("BuyPrice")] public long BuyPrice { get; private set; }

        [JsonProperty("TotalCost")] public long TotalCost { get; private set; }
    }

    public partial class MarketBuyEvent
    {
        public static MarketBuyEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MarketBuyEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<MarketBuyEvent> MarketBuyEvent;

    }
}