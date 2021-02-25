using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class PowerplayCollectEvent : EventBase
    {
        internal PowerplayCollectEvent()
        {
        }

        [JsonProperty("Power")] public string Power { get; private set; }

        [JsonProperty("Type")] public string Type { get; private set; }

        [JsonProperty("Type_Localised")] public string TypeLocalised { get; private set; }

        [JsonProperty("Count")] public long Count { get; private set; }
    }

    public partial class PowerplayCollectEvent
    {
        public static PowerplayCollectEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PowerplayCollectEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<PowerplayCollectEvent> PowerplayCollectEvent;

    }
}