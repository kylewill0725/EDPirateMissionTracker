using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class FactionKillBondEvent : EventBase
    {
        internal FactionKillBondEvent()
        {
        }

        [JsonProperty("Reward")] public long Reward { get; private set; }

        [JsonProperty("AwardingFaction")] public string AwardingFaction { get; private set; }

        [JsonProperty("VictimFaction")] public string VictimFaction { get; private set; }
    }

    public partial class FactionKillBondEvent
    {
        public static FactionKillBondEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<FactionKillBondEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<FactionKillBondEvent> FactionKillBondEvent;

    }
}