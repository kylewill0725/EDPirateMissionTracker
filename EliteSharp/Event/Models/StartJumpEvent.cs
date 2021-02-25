using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class StartJumpEvent : EventBase
    {
        internal StartJumpEvent()
        {
        }

        [JsonProperty("JumpType")] public string JumpType { get; private set; }
    }

    public partial class StartJumpEvent
    {
        public static StartJumpEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<StartJumpEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<StartJumpEvent> StartJumpEvent;

    }
}