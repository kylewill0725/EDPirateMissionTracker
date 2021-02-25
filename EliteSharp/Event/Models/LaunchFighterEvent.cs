using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class LaunchFighterEvent : EventBase
    {
        internal LaunchFighterEvent()
        {
        }

        [JsonProperty("Loadout")] public string Loadout { get; private set; }

        [JsonProperty("ID")] public long Id { get; private set; }

        [JsonProperty("PlayerControlled")] public bool PlayerControlled { get; private set; }
    }

    public partial class LaunchFighterEvent
    {
        public static LaunchFighterEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<LaunchFighterEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<LaunchFighterEvent> LaunchFighterEvent;

    }
}