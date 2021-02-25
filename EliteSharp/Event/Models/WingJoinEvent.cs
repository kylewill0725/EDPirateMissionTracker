using System;
using System.Collections.Generic;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class WingJoinEvent : EventBase
    {
        internal WingJoinEvent()
        {
        }

        [JsonProperty("Others")] public IReadOnlyList<string> Others { get; private set; }
    }

    public partial class WingJoinEvent
    {
        public static WingJoinEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<WingJoinEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<WingJoinEvent> WingJoinEvent;

    }
}