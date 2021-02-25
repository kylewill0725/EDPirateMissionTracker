using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class DockingGrantedEvent : EventBase
    {
        internal DockingGrantedEvent()
        {
        }

        [JsonProperty("LandingPad")] public long LandingPad { get; private set; }

        [JsonProperty("MarketID")] public long MarketId { get; private set; }

        [JsonProperty("StationName")] public string StationName { get; private set; }

        [JsonProperty("StationType")] public string StationType { get; private set; }
    }

    public partial class DockingGrantedEvent
    {
        public static DockingGrantedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<DockingGrantedEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<DockingGrantedEvent> DockingGrantedEvent;

    }
}