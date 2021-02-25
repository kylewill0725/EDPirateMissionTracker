using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class SellDronesEvent : EventBase
    {
        internal SellDronesEvent()
        {
        }

        [JsonProperty("Type")] public string Type { get; private set; }

        [JsonProperty("Count")] public long Count { get; private set; }

        [JsonProperty("SellPrice")] public long SellPrice { get; private set; }

        [JsonProperty("TotalSale")] public long TotalSale { get; private set; }
    }

    public partial class SellDronesEvent
    {
        public static SellDronesEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SellDronesEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<SellDronesEvent> SellDronesEvent;

    }
}