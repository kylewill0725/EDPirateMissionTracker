using System;
using System.Collections.Generic;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class SynthesisEvent : EventBase
    {
        internal SynthesisEvent()
        {
        }

        [JsonProperty("Name")] public string Name { get; private set; }

        [JsonProperty("Materials")] public IReadOnlyList<Material> Materials { get; private set; }
    }

    public class Material
    {
        internal Material()
        {
        }

        [JsonProperty("Name")] public string Name { get; private set; }

        [JsonProperty("Count")] public long Count { get; private set; }
    }

    public partial class SynthesisEvent
    {
        public static SynthesisEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SynthesisEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<SynthesisEvent> SynthesisEvent;

    }
}