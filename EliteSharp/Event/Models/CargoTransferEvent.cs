using System;
using System.Collections.Generic;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class CargoTransferEvent : EventBase
    {
        internal CargoTransferEvent()
        {
        }

        [JsonProperty("Transfers")] public IReadOnlyList<Transfer> Transfers { get; private set; }
    }

    public class Transfer
    {
        internal Transfer()
        {
        }

        [JsonProperty("Type")] public string Type { get; private set; }

        [JsonProperty("Count")] public long Count { get; private set; }

        [JsonProperty("Direction")] public string Direction { get; private set; }
    }

    public partial class CargoTransferEvent
    {
        public static CargoTransferEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CargoTransferEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<CargoTransferEvent> CargoTransferEvent;

    }
}