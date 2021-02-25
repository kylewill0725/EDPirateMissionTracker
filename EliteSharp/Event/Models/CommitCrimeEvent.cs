using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class CommitCrimeEvent : EventBase
    {
        internal CommitCrimeEvent()
        {
        }

        [JsonProperty("CrimeType")] public string CrimeType { get; private set; }

        [JsonProperty("Faction")] public string Faction { get; private set; }

        [JsonProperty("Fine")] public long Fine { get; private set; }
    }

    public partial class CommitCrimeEvent
    {
        public static CommitCrimeEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CommitCrimeEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<CommitCrimeEvent> CommitCrimeEvent;

    }
}