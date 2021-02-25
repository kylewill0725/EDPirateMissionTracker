using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class ModuleSellEvent : EventBase
    {
        internal ModuleSellEvent()
        {
        }

        [JsonProperty("MarketID")] public long MarketId { get; private set; }

        [JsonProperty("Slot")] public string Slot { get; private set; }

        [JsonProperty("SellItem")] public string SellItem { get; private set; }

        [JsonProperty("SellItem_Localised")] public string SellItemLocalised { get; private set; }

        [JsonProperty("SellPrice")] public long SellPrice { get; private set; }

        [JsonProperty("Ship")] public string Ship { get; private set; }

        [JsonProperty("ShipID")] public long ShipId { get; private set; }
    }

    public partial class ModuleSellEvent
    {
        public static ModuleSellEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ModuleSellEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<ModuleSellEvent> ModuleSellEvent;

    }
}