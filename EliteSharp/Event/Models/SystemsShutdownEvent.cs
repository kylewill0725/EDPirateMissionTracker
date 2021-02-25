using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class SystemsShutdownEvent : EventBase
    {
        internal SystemsShutdownEvent()
        {
        }

        [JsonProperty("event")] public string Event { get; private set; }
    }

    public partial class SystemsShutdownEvent
    {
        public static SystemsShutdownEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SystemsShutdownEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<SystemsShutdownEvent> SystemsShutdownEvent;

    }
}