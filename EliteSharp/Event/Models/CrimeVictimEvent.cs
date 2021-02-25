using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class CrimeVictimEvent : EventBase
    {
        internal CrimeVictimEvent()
        {
        }

        [JsonProperty("Offender")] public string Offender { get; private set; }

        [JsonProperty("CrimeType")] public string CrimeType { get; private set; }

        [JsonProperty("Bounty")] public long Bounty { get; private set; }
    }

    public partial class CrimeVictimEvent
    {
        public static CrimeVictimEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CrimeVictimEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<CrimeVictimEvent> CrimeVictimEvent;

    }
}