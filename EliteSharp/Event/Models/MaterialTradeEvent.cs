using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class MaterialTradeEvent : EventBase
    {
        internal MaterialTradeEvent() { }

        [JsonProperty("MarketID")]
        public long MarketId { get; private set; }

        [JsonProperty("TraderType")]
        public string TraderType { get; private set; }

        [JsonProperty("Paid")]
        public Paid Paid { get; private set; }

        [JsonProperty("Received")]
        public Paid Received { get; private set; }
    }

    public partial class Paid
    {
        internal Paid() { }

        [JsonProperty("Material")]
        public string Material { get; private set; }

        [JsonProperty("Material_Localised")]
        public string MaterialLocalised { get; private set; }

        [JsonProperty("Category")]
        public string Category { get; private set; }

        [JsonProperty("Quantity")]
        public long Quantity { get; private set; }
    }

    public partial class MaterialTradeEvent
    {
        public static MaterialTradeEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MaterialTradeEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<MaterialTradeEvent> MaterialTradeEvent;
    }
}