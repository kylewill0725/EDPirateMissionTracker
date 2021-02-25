using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class PowerplayDeliverEvent : EventBase
    {
        internal PowerplayDeliverEvent()
        {
        }

        [JsonProperty("Power")] public string Power { get; private set; }

        [JsonProperty("Type")] public string Type { get; private set; }

        [JsonProperty("Type_Localised")] public string TypeLocalised { get; private set; }

        [JsonProperty("Count")] public long Count { get; private set; }
    }

    public partial class PowerplayDeliverEvent
    {
        public static PowerplayDeliverEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PowerplayDeliverEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<PowerplayDeliverEvent> PowerplayDeliverEvent;

    }
}