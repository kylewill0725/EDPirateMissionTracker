using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class MaterialDiscardedEvent : EventBase
    {
        internal MaterialDiscardedEvent()
        {
        }

        [JsonProperty("Category")] public string Category { get; private set; }

        [JsonProperty("Name")] public string Name { get; private set; }

        [JsonProperty("Count")] public long Count { get; private set; }
    }

    public partial class MaterialDiscardedEvent
    {
        public static MaterialDiscardedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MaterialDiscardedEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<MaterialDiscardedEvent> MaterialDiscardedEvent;

    }
}