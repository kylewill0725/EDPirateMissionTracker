using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class ShutdownEvent : EventBase
    {
        internal ShutdownEvent()
        {
        }

        [JsonProperty("event")] public string Event { get; private set; }
    }

    public partial class ShutdownEvent
    {
        public static ShutdownEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ShutdownEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<ShutdownEvent> ShutdownEvent;

    }
}