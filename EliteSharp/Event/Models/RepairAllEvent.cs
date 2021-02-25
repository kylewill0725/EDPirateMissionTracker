using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class RepairAllEvent : EventBase
    {
        internal RepairAllEvent()
        {
        }

        [JsonProperty("Cost")] public long Cost { get; private set; }
    }

    public partial class RepairAllEvent
    {
        public static RepairAllEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<RepairAllEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<RepairAllEvent> RepairAllEvent;

    }
}