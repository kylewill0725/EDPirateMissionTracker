using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class FssSignalDiscoveredEvent : EventBase
    {
        internal FssSignalDiscoveredEvent()
        {
        }

        [JsonProperty("SystemAddress")] public long SystemAddress { get; private set; }

        [JsonProperty("SignalName")] public string SignalName { get; private set; }
    }

    public partial class FssSignalDiscoveredEvent
    {
        public static FssSignalDiscoveredEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<FssSignalDiscoveredEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<FssSignalDiscoveredEvent> FssSignalDiscoveredEvent;

    }
}