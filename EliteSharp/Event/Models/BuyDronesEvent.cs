using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class BuyDronesEvent : EventBase
    {
        internal BuyDronesEvent()
        {
        }

        [JsonProperty("Type")] public string Type { get; private set; }

        [JsonProperty("Count")] public long Count { get; private set; }

        [JsonProperty("BuyPrice")] public long BuyPrice { get; private set; }

        [JsonProperty("TotalCost")] public long TotalCost { get; private set; }
    }

    public partial class BuyDronesEvent
    {
        public static BuyDronesEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<BuyDronesEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<BuyDronesEvent> BuyDronesEvent;

    }
}