using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class OutfittingEvent : EventBase
    {
        internal OutfittingEvent()
        {
        }

        [JsonProperty("MarketID")] public long MarketId { get; private set; }

        [JsonProperty("StationName")] public string StationName { get; private set; }

        [JsonProperty("StarSystem")] public string StarSystem { get; private set; }
    }

    public partial class OutfittingEvent
    {
        public static OutfittingEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<OutfittingEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<OutfittingEvent> OutfittingEvent;

    }
}