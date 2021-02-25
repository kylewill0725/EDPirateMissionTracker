using System;
using System.Collections.Generic;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class MissionsEvent : EventBase
    {
        internal MissionsEvent()
        {
        }

        [JsonProperty("Active")] public IReadOnlyList<object> Active { get; private set; }

        [JsonProperty("Failed")] public IReadOnlyList<object> Failed { get; private set; }

        [JsonProperty("Complete")] public IReadOnlyList<object> Complete { get; private set; }
    }

    public partial class MissionsEvent
    {
        public static MissionsEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MissionsEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<MissionsEvent> MissionsEvent;

    }
}