using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class ResurrectEvent : EventBase
    {
        internal ResurrectEvent()
        {
        }

        [JsonProperty("Option")] public string Option { get; private set; }

        [JsonProperty("Cost")] public long Cost { get; private set; }

        [JsonProperty("Bankrupt")] public bool Bankrupt { get; private set; }
    }

    public partial class ResurrectEvent
    {
        public static ResurrectEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ResurrectEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<ResurrectEvent> ResurrectEvent;

    }
}