using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class ShieldStateEvent : EventBase
    {
        internal ShieldStateEvent()
        {
        }

        [JsonProperty("ShieldsUp")] public bool ShieldsUp { get; private set; }
    }

    public partial class ShieldStateEvent
    {
        public static ShieldStateEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ShieldStateEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<ShieldStateEvent> ShieldStateEvent;

    }
}