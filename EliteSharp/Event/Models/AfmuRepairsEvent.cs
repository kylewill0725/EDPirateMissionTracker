using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class AfmuRepairsEvent : EventBase
    {
        internal AfmuRepairsEvent()
        {
        }

        [JsonProperty("Module")] public string Module { get; private set; }

        [JsonProperty("Module_Localised")] public string ModuleLocalised { get; private set; }

        [JsonProperty("FullyRepaired")] public bool FullyRepaired { get; private set; }

        [JsonProperty("Health")] public double Health { get; private set; }
    }

    public partial class AfmuRepairsEvent
    {
        public static AfmuRepairsEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<AfmuRepairsEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<AfmuRepairsEvent> AfmuRepairsEvent;

    }

// public partial class EventHandler : IEventHandler
// {
// }
}