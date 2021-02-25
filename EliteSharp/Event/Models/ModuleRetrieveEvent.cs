using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class ModuleRetrieveEvent : EventBase
    {
        internal ModuleRetrieveEvent()
        {
        }

        [JsonProperty("MarketID")] public long MarketId { get; private set; }

        [JsonProperty("Slot")] public string Slot { get; private set; }

        [JsonProperty("RetrievedItem")] public string RetrievedItem { get; private set; }

        [JsonProperty("RetrievedItem_Localised")]
        public string RetrievedItemLocalised { get; private set; }

        [JsonProperty("Ship")] public string Ship { get; private set; }

        [JsonProperty("ShipID")] public long ShipId { get; private set; }

        [JsonProperty("Hot")] public bool Hot { get; private set; }
    }

    public partial class ModuleRetrieveEvent
    {
        public static ModuleRetrieveEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ModuleRetrieveEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<ModuleRetrieveEvent> ModuleRetrieveEvent;

    }
}