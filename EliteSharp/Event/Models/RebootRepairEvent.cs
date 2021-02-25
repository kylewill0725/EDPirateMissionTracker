using System;
using System.Collections.Generic;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class RebootRepairEvent : EventBase
    {
        internal RebootRepairEvent()
        {
        }

        [JsonProperty("Modules")] public IReadOnlyList<object> Modules { get; private set; }
    }

    public partial class RebootRepairEvent
    {
        public static RebootRepairEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<RebootRepairEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<RebootRepairEvent> RebootRepairEvent;

    }
}