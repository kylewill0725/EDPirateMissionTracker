using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class NavRouteEvent : EventBase
    {
        internal NavRouteEvent()
        {
        }

        [JsonProperty("event")] public string Event { get; private set; }
    }

    public partial class NavRouteEvent
    {
        public static NavRouteEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<NavRouteEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<NavRouteEvent> NavRouteEvent;

    }
}