using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class PowerplayEvent : EventBase
    {
        internal PowerplayEvent()
        {
        }

        [JsonProperty("Power")] public string Power { get; private set; }

        [JsonProperty("Rank")] public long Rank { get; private set; }

        [JsonProperty("Merits")] public long Merits { get; private set; }

        [JsonProperty("Votes")] public long Votes { get; private set; }

        [JsonProperty("TimePledged")] public long TimePledged { get; private set; }
    }

    public partial class PowerplayEvent
    {
        public static PowerplayEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PowerplayEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<PowerplayEvent> PowerplayEvent;

    }
}