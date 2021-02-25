using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class PvpKillEvent : EventBase
    {
        internal PvpKillEvent()
        {
        }

        [JsonProperty("Victim")] public string Victim { get; private set; }

        [JsonProperty("CombatRank")] public long CombatRank { get; private set; }
    }

    public partial class PvpKillEvent
    {
        public static PvpKillEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PvpKillEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<PvpKillEvent> PvpKillEvent;

    }
}