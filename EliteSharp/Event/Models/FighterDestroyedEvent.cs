using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class FighterDestroyedEvent : EventBase
    {
        internal FighterDestroyedEvent()
        {
        }

        [JsonProperty("ID")] public long Id { get; private set; }
    }

    public partial class FighterDestroyedEvent
    {
        public static FighterDestroyedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<FighterDestroyedEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<FighterDestroyedEvent> FighterDestroyedEvent;

    }
}