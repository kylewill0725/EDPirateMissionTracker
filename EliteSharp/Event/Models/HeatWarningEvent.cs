using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class HeatWarningEvent : EventBase
    {
        internal HeatWarningEvent()
        {
        }

        [JsonProperty("event")] public string Event { get; private set; }
    }

    public partial class HeatWarningEvent
    {
        public static HeatWarningEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<HeatWarningEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<HeatWarningEvent> HeatWarningEvent;

    }
}