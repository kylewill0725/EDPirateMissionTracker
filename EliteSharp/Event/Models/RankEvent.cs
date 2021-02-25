using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class RankEvent : EventBase
    {
        internal RankEvent()
        {
        }

        [JsonProperty("Combat")] public long Combat { get; private set; }

        [JsonProperty("Trade")] public long Trade { get; private set; }

        [JsonProperty("Explore")] public long Explore { get; private set; }

        [JsonProperty("Empire")] public long Empire { get; private set; }

        [JsonProperty("Federation")] public long Federation { get; private set; }

        [JsonProperty("CQC")] public long Cqc { get; private set; }
    }

    public partial class RankEvent
    {
        public static RankEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<RankEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<RankEvent> RankEvent;

    }
}