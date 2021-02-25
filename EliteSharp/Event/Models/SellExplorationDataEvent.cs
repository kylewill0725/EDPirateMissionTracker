using System;
using System.Collections.Generic;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class SellExplorationDataEvent : EventBase
    {
        internal SellExplorationDataEvent()
        {
        }

        [JsonProperty("Systems")] public IReadOnlyList<string> Systems { get; private set; }

        [JsonProperty("Discovered")] public IReadOnlyList<object> Discovered { get; private set; }

        [JsonProperty("BaseValue")] public long BaseValue { get; private set; }

        [JsonProperty("Bonus")] public long Bonus { get; private set; }
    }

    public partial class SellExplorationDataEvent
    {
        public static SellExplorationDataEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SellExplorationDataEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<SellExplorationDataEvent> SellExplorationDataEvent;

    }
}