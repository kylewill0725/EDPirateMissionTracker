using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class ModuleSwapEvent : EventBase
    {
        internal ModuleSwapEvent()
        {
        }

        [JsonProperty("MarketID")] public long MarketId { get; private set; }

        [JsonProperty("FromSlot")] public string FromSlot { get; private set; }

        [JsonProperty("ToSlot")] public string ToSlot { get; private set; }

        [JsonProperty("FromItem")] public string FromItem { get; private set; }

        [JsonProperty("FromItem_Localised")] public string FromItemLocalised { get; private set; }

        [JsonProperty("ToItem")] public string ToItem { get; private set; }

        [JsonProperty("ToItem_Localised")] public string ToItemLocalised { get; private set; }

        [JsonProperty("Ship")] public string Ship { get; private set; }

        [JsonProperty("ShipID")] public long ShipId { get; private set; }
    }

    public partial class ModuleSwapEvent
    {
        public static ModuleSwapEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ModuleSwapEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<ModuleSwapEvent> ModuleSwapEvent;

    }
}