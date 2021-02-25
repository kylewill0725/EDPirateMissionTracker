using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class ProgressEvent : EventBase
    {
        internal ProgressEvent()
        {
        }

        [JsonProperty("Combat")] public long Combat { get; private set; }

        [JsonProperty("Trade")] public long Trade { get; private set; }

        [JsonProperty("Explore")] public long Explore { get; private set; }

        [JsonProperty("Empire")] public long Empire { get; private set; }

        [JsonProperty("Federation")] public long Federation { get; private set; }

        [JsonProperty("CQC")] public long Cqc { get; private set; }
    }

    public partial class ProgressEvent
    {
        public static ProgressEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ProgressEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<ProgressEvent> ProgressEvent;

    }
}