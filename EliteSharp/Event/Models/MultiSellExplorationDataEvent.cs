using System;
using System.Collections.Generic;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class MultiSellExplorationDataEvent : EventBase
    {
        internal MultiSellExplorationDataEvent()
        {
        }

        [JsonProperty("Discovered")] public IReadOnlyList<Discovered> Discovered { get; private set; }

        [JsonProperty("BaseValue")] public long BaseValue { get; private set; }

        [JsonProperty("Bonus")] public long Bonus { get; private set; }

        [JsonProperty("TotalEarnings")] public long TotalEarnings { get; private set; }
    }

    public class Discovered
    {
        internal Discovered()
        {
        }

        [JsonProperty("SystemName")] public string SystemName { get; private set; }

        [JsonProperty("NumBodies")] public long NumBodies { get; private set; }
    }

    public partial class MultiSellExplorationDataEvent
    {
        public static MultiSellExplorationDataEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MultiSellExplorationDataEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<MultiSellExplorationDataEvent> MultiSellExplorationDataEvent;

    }
}