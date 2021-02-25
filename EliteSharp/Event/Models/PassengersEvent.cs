using System;
using System.Collections.Generic;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class PassengersEvent : EventBase
    {
        internal PassengersEvent()
        {
        }

        [JsonProperty("Manifest")] public IReadOnlyList<Manifest> Manifest { get; private set; }
    }

    public class Manifest
    {
        internal Manifest()
        {
        }

        [JsonProperty("MissionID")] public long MissionId { get; private set; }

        [JsonProperty("Type")] public string Type { get; private set; }

        [JsonProperty("VIP")] public bool Vip { get; private set; }

        [JsonProperty("Wanted")] public bool Wanted { get; private set; }

        [JsonProperty("Count")] public long Count { get; private set; }
    }

    public partial class PassengersEvent
    {
        public static PassengersEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PassengersEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<PassengersEvent> PassengersEvent;

    }
}