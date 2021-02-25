using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class CrewHireEvent : EventBase
    {
        internal CrewHireEvent()
        {
        }

        [JsonProperty("Name")] public string Name { get; private set; }

        [JsonProperty("Faction")] public string Faction { get; private set; }

        [JsonProperty("Cost")] public long Cost { get; private set; }

        [JsonProperty("CombatRank")] public long CombatRank { get; private set; }
    }

    public partial class CrewHireEvent
    {
        public static CrewHireEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CrewHireEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<CrewHireEvent> CrewHireEvent;

    }
}