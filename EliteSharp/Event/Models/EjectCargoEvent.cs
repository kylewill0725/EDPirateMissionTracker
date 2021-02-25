using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class EjectCargoEvent : EventBase
    {
        internal EjectCargoEvent()
        {
        }

        [JsonProperty("Type")] public string Type { get; private set; }

        [JsonProperty("Type_Localised")] public string TypeLocalised { get; private set; }

        [JsonProperty("Count")] public long Count { get; private set; }

        [JsonProperty("Abandoned")] public bool Abandoned { get; private set; }
    }

    public partial class EjectCargoEvent
    {
        public static EjectCargoEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<EjectCargoEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<EjectCargoEvent> EjectCargoEvent;

    }
}