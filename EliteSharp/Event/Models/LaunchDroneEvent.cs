using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class LaunchDroneEvent : EventBase
    {
        internal LaunchDroneEvent()
        {
        }

        [JsonProperty("Type")] public string Type { get; private set; }
    }

    public partial class LaunchDroneEvent
    {
        public static LaunchDroneEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<LaunchDroneEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<LaunchDroneEvent> LaunchDroneEvent;

    }
}