using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class MaterialCollectedEvent : EventBase
    {
        internal MaterialCollectedEvent()
        {
        }

        [JsonProperty("Category")] public string Category { get; private set; }

        [JsonProperty("Name")] public string Name { get; private set; }

        [JsonProperty("Name_Localised")] public string NameLocalised { get; private set; }

        [JsonProperty("Count")] public long Count { get; private set; }
    }

    public partial class MaterialCollectedEvent
    {
        public static MaterialCollectedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MaterialCollectedEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<MaterialCollectedEvent> MaterialCollectedEvent;

    }
}