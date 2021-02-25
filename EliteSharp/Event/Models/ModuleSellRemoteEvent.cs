using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class ModuleSellRemoteEvent : EventBase
    {
        internal ModuleSellRemoteEvent()
        {
        }

        [JsonProperty("StorageSlot")] public long StorageSlot { get; private set; }

        [JsonProperty("SellItem")] public string SellItem { get; private set; }

        [JsonProperty("SellItem_Localised")] public string SellItemLocalised { get; private set; }

        [JsonProperty("ServerId")] public long ServerId { get; private set; }

        [JsonProperty("SellPrice")] public long SellPrice { get; private set; }

        [JsonProperty("Ship")] public string Ship { get; private set; }

        [JsonProperty("ShipID")] public long ShipId { get; private set; }
    }

    public partial class ModuleSellRemoteEvent
    {
        public static ModuleSellRemoteEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ModuleSellRemoteEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<ModuleSellRemoteEvent> ModuleSellRemoteEvent;

    }
}