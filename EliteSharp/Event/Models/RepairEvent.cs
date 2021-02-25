using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class RepairEvent : EventBase
    {
        internal RepairEvent()
        {
        }

        [JsonProperty("Item")] public string Item { get; private set; }

        [JsonProperty("Cost")] public long Cost { get; private set; }
    }

    public partial class RepairEvent
    {
        public static RepairEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<RepairEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<RepairEvent> RepairEvent;

    }
}