using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class PowerplayVoteEvent : EventBase
    {
        internal PowerplayVoteEvent()
        {
        }

        [JsonProperty("Power")] public string Power { get; private set; }

        [JsonProperty("Votes")] public long Votes { get; private set; }

        [JsonProperty("")] public long Empty { get; private set; }
    }

    public partial class PowerplayVoteEvent
    {
        public static PowerplayVoteEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PowerplayVoteEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<PowerplayVoteEvent> PowerplayVoteEvent;

    }
}