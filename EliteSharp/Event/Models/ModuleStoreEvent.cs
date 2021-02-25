using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class ModuleStoreEvent : EventBase
    {
        internal ModuleStoreEvent()
        {
        }

        [JsonProperty("Slot")] public string Slot { get; private set; }

        [JsonProperty("StoredItem")] public string StoredItem { get; private set; }

        [JsonProperty("StoredItem_Localised")] public string StoredItemLocalised { get; private set; }

        [JsonProperty("Ship")] public string Ship { get; private set; }

        [JsonProperty("ShipID")] public long ShipId { get; private set; }

        [JsonProperty("EngineerModifications")]
        public string EngineerModifications { get; private set; }
    }

    public partial class ModuleStoreEvent
    {
        public static ModuleStoreEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ModuleStoreEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<ModuleStoreEvent> ModuleStoreEvent;

    }
}