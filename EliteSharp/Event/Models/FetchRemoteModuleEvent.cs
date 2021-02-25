using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class FetchRemoteModuleEvent : EventBase
    {
        internal FetchRemoteModuleEvent()
        {
        }

        [JsonProperty("StorageSlot")] public long StorageSlot { get; private set; }

        [JsonProperty("StoredItem")] public string StoredItem { get; private set; }

        [JsonProperty("StoredItem_Localised")] public string StoredItemLocalised { get; private set; }

        [JsonProperty("ServerId")] public long ServerId { get; private set; }

        [JsonProperty("TransferCost")] public long TransferCost { get; private set; }

        [JsonProperty("TransferTime")] public long TransferTime { get; private set; }

        [JsonProperty("Ship")] public string Ship { get; private set; }

        [JsonProperty("ShipID")] public long ShipId { get; private set; }
    }

    public partial class FetchRemoteModuleEvent
    {
        public static FetchRemoteModuleEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<FetchRemoteModuleEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<FetchRemoteModuleEvent> FetchRemoteModuleEvent;

    }
}