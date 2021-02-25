using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class EscapeInterdictionEvent : EventBase
    {
        internal EscapeInterdictionEvent()
        {
        }

        [JsonProperty("Interdictor")] public string Interdictor { get; private set; }

        [JsonProperty("IsPlayer")] public bool IsPlayer { get; private set; }
    }

    public partial class EscapeInterdictionEvent
    {
        public static EscapeInterdictionEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<EscapeInterdictionEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<EscapeInterdictionEvent> EscapeInterdictionEvent;

    }
}