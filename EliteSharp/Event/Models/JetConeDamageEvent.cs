using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class JetConeDamageEvent : EventBase
    {
        internal JetConeDamageEvent()
        {
        }

        [JsonProperty("Module")] public string Module { get; private set; }

        [JsonProperty("Module_Localised")] public string ModuleLocalised { get; private set; }
    }

    public partial class JetConeDamageEvent
    {
        public static JetConeDamageEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<JetConeDamageEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<JetConeDamageEvent> JetConeDamageEvent;

    }
}