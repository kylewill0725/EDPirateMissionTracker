using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class CollectCargoEvent : EventBase
    {
        internal CollectCargoEvent()
        {
        }

        [JsonProperty("Type")] public string Type { get; private set; }

        [JsonProperty("Type_Localised")] public string TypeLocalised { get; private set; }

        [JsonProperty("Stolen")] public bool Stolen { get; private set; }
    }

    public partial class CollectCargoEvent
    {
        public static CollectCargoEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CollectCargoEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<CollectCargoEvent> CollectCargoEvent;

    }
}