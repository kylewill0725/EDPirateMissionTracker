using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class DiedEvent : EventBase
    {
        internal DiedEvent()
        {
        }

        [JsonProperty("event")] public string Event { get; private set; }
    }

    public partial class DiedEvent
    {
        public static DiedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<DiedEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<DiedEvent> DiedEvent;

    }
}