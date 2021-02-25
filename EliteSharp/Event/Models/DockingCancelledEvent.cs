using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class DockingCancelledEvent : EventBase
    {
        internal DockingCancelledEvent()
        {
        }

        [JsonProperty("StationName")] public string StationName { get; private set; }
    }

    public partial class DockingCancelledEvent
    {
        public static DockingCancelledEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<DockingCancelledEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<DockingCancelledEvent> DockingCancelledEvent;

    }
}