using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class DockFighterEvent : EventBase
    {
        internal DockFighterEvent()
        {
        }

        [JsonProperty("ID")] public long Id { get; private set; }
    }

    public partial class DockFighterEvent
    {
        public static DockFighterEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<DockFighterEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<DockFighterEvent> DockFighterEvent;

    }
}