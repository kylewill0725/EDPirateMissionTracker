using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class MarketEvent : EventBase
    {
        internal MarketEvent()
        {
        }

        [JsonProperty("MarketID")] public long MarketId { get; private set; }

        [JsonProperty("StationName")] public string StationName { get; private set; }

        [JsonProperty("StarSystem")] public string StarSystem { get; private set; }
    }

    public partial class MarketEvent
    {
        public static MarketEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MarketEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<MarketEvent> MarketEvent;

    }
}