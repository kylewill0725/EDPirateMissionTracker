using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class FsdTargetEvent : EventBase
    {
        internal FsdTargetEvent()
        {
        }

        [JsonProperty("Name")] public string Name { get; private set; }

        [JsonProperty("SystemAddress")] public long SystemAddress { get; private set; }

        [JsonProperty("StarClass")] public string StarClass { get; private set; }
    }

    public partial class FsdTargetEvent
    {
        public static FsdTargetEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<FsdTargetEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<FsdTargetEvent> FsdTargetEvent;

    }
}