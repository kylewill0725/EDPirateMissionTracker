using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class SelfDestructEvent : EventBase
    {
        internal SelfDestructEvent()
        {
        }

        [JsonProperty("event")] public string Event { get; private set; }
    }

    public partial class SelfDestructEvent
    {
        public static SelfDestructEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SelfDestructEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<SelfDestructEvent> SelfDestructEvent;

    }
}