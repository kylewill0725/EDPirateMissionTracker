using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class CrewLaunchFighterEvent : EventBase
    {
        internal CrewLaunchFighterEvent()
        {
        }

        [JsonProperty("Crew")] public string Crew { get; private set; }
    }

    public partial class CrewLaunchFighterEvent
    {
        public static CrewLaunchFighterEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CrewLaunchFighterEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<CrewLaunchFighterEvent> CrewLaunchFighterEvent;

    }
}