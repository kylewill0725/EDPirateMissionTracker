using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class SquadronStartupEvent : EventBase
    {
        internal SquadronStartupEvent()
        {
        }

        [JsonProperty("SquadronName")] public string SquadronName { get; private set; }

        [JsonProperty("CurrentRank")] public long CurrentRank { get; private set; }
    }

    public partial class SquadronStartupEvent
    {
        public static SquadronStartupEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SquadronStartupEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<SquadronStartupEvent> SquadronStartupEvent;

    }
}