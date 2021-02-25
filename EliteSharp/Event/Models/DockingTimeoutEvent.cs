using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class DockingTimeoutEvent : EventBase
    {
        internal DockingTimeoutEvent()
        {
        }

        [JsonProperty("StationName")] public string StationName { get; private set; }
    }

    public partial class DockingTimeoutEvent
    {
        public static DockingTimeoutEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<DockingTimeoutEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<DockingTimeoutEvent> DockingTimeoutEvent;

    }
}