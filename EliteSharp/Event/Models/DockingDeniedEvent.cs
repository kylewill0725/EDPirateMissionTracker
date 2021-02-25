using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class DockingDeniedEvent : EventBase
    {
        internal DockingDeniedEvent()
        {
        }

        [JsonProperty("Reason")] public string Reason { get; private set; }

        [JsonProperty("MarketID")] public long MarketId { get; private set; }

        [JsonProperty("StationName")] public string StationName { get; private set; }

        [JsonProperty("StationType")] public string StationType { get; private set; }
    }

    public partial class DockingDeniedEvent
    {
        public static DockingDeniedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<DockingDeniedEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<DockingDeniedEvent> DockingDeniedEvent;

    }
}