using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class WingLeaveEvent : EventBase
    {
        internal WingLeaveEvent()
        {
        }

        [JsonProperty("event")] public string Event { get; private set; }
    }

    public partial class WingLeaveEvent
    {
        public static WingLeaveEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<WingLeaveEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<WingLeaveEvent> WingLeaveEvent;

    }
}