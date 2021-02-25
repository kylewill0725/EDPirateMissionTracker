using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class MiningRefinedEvent : EventBase
    {
        internal MiningRefinedEvent()
        {
        }

        [JsonProperty("Type")] public string Type { get; private set; }

        [JsonProperty("Type_Localised")] public string TypeLocalised { get; private set; }
    }

    public partial class MiningRefinedEvent
    {
        public static MiningRefinedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MiningRefinedEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<MiningRefinedEvent> MiningRefinedEvent;

    }
}