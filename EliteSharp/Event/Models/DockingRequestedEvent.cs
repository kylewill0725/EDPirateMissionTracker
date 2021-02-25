using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class DockingRequestedEvent : EventBase
    {
        internal DockingRequestedEvent()
        {
        }

        [JsonProperty("MarketID")] public long MarketId { get; private set; }

        [JsonProperty("StationName")] public string StationName { get; private set; }

        [JsonProperty("StationType")] public string StationType { get; private set; }
    }

    public partial class DockingRequestedEvent
    {
        public static DockingRequestedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<DockingRequestedEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<DockingRequestedEvent> DockingRequestedEvent;

    }
}