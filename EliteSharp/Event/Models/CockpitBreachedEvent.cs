using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class CockpitBreachedEvent : EventBase
    {
        internal CockpitBreachedEvent()
        {
        }
    }

    public partial class CockpitBreachedEvent
    {
        public static CockpitBreachedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CockpitBreachedEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<CockpitBreachedEvent> CockpitBreachedEvent;

    }
}