using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class MaterialDiscoveredEvent : EventBase
    {
        internal MaterialDiscoveredEvent()
        {
        }

        [JsonProperty("Category")] public string Category { get; private set; }

        [JsonProperty("Name")] public string Name { get; private set; }

        [JsonProperty("DiscoveryNumber")] public long DiscoveryNumber { get; private set; }
    }

    public partial class MaterialDiscoveredEvent
    {
        public static MaterialDiscoveredEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MaterialDiscoveredEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<MaterialDiscoveredEvent> MaterialDiscoveredEvent;

    }
}