using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class ModuleBuyEvent : EventBase
    {
        internal ModuleBuyEvent()
        {
        }

        [JsonProperty("Slot")] public string Slot { get; private set; }

        [JsonProperty("BuyItem")] public string BuyItem { get; private set; }

        [JsonProperty("BuyItem_Localised")] public string BuyItemLocalised { get; private set; }

        [JsonProperty("MarketID")] public long MarketId { get; private set; }

        [JsonProperty("BuyPrice")] public long BuyPrice { get; private set; }

        [JsonProperty("Ship")] public string Ship { get; private set; }

        [JsonProperty("ShipID")] public long ShipId { get; private set; }
    }

    public partial class ModuleBuyEvent
    {
        public static ModuleBuyEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ModuleBuyEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<ModuleBuyEvent> ModuleBuyEvent;

    }
}