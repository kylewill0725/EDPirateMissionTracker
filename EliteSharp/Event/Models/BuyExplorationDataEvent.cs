using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class BuyExplorationDataEvent : EventBase
    {
        internal BuyExplorationDataEvent()
        {
        }

        [JsonProperty("System")] public string System { get; private set; }

        [JsonProperty("Cost")] public long Cost { get; private set; }
    }

    public partial class BuyExplorationDataEvent
    {
        public static BuyExplorationDataEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<BuyExplorationDataEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<BuyExplorationDataEvent> BuyExplorationDataEvent;

    }
}