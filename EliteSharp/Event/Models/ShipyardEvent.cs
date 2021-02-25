using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class ShipyardEvent : EventBase
    {
        internal ShipyardEvent()
        {
        }

        [JsonProperty("MarketID")] public long MarketId { get; private set; }

        [JsonProperty("StationName")] public string StationName { get; private set; }

        [JsonProperty("StarSystem")] public string StarSystem { get; private set; }
    }

    public partial class ShipyardEvent
    {
        public static ShipyardEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ShipyardEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<ShipyardEvent> ShipyardEvent;

    }
}