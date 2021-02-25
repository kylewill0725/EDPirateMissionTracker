using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class JetConeBoostEvent : EventBase
    {
        internal JetConeBoostEvent()
        {
        }

        [JsonProperty("BoostValue")] public double BoostValue { get; private set; }
    }

    public partial class JetConeBoostEvent
    {
        public static JetConeBoostEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<JetConeBoostEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<JetConeBoostEvent> JetConeBoostEvent;

    }
}