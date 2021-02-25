using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class SearchAndRescueEvent : EventBase
    {
        internal SearchAndRescueEvent()
        {
        }

        [JsonProperty("Name")] public string Name { get; private set; }

        [JsonProperty("Count")] public long Count { get; private set; }

        [JsonProperty("Reward")] public long Reward { get; private set; }
    }

    public partial class SearchAndRescueEvent
    {
        public static SearchAndRescueEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SearchAndRescueEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<SearchAndRescueEvent> SearchAndRescueEvent;

    }
}