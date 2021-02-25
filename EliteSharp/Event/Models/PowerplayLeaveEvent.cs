using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class PowerplayLeaveEvent : EventBase
    {
        internal PowerplayLeaveEvent()
        {
        }

        [JsonProperty("Power")] public string Power { get; private set; }
    }

    public partial class PowerplayLeaveEvent
    {
        public static PowerplayLeaveEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PowerplayLeaveEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<PowerplayLeaveEvent> PowerplayLeaveEvent;

    }
}