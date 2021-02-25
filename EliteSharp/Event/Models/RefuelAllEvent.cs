using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class RefuelAllEvent : EventBase
    {
        internal RefuelAllEvent()
        {
        }

        [JsonProperty("Cost")] public long Cost { get; private set; }

        [JsonProperty("Amount")] public double Amount { get; private set; }
    }

    public partial class RefuelAllEvent
    {
        public static RefuelAllEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<RefuelAllEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<RefuelAllEvent> RefuelAllEvent;

    }
}