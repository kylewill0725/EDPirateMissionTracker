using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class FighterRebuiltEvent : EventBase
    {
        internal FighterRebuiltEvent()
        {
        }

        [JsonProperty("Loadout")] public string Loadout { get; private set; }

        [JsonProperty("ID")] public long Id { get; private set; }
    }

    public partial class FighterRebuiltEvent
    {
        public static FighterRebuiltEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<FighterRebuiltEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<FighterRebuiltEvent> FighterRebuiltEvent;

    }
}