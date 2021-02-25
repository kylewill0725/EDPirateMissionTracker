using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class PowerplayFastTrackEvent : EventBase
    {
        internal PowerplayFastTrackEvent()
        {
        }

        [JsonProperty("Power")] public string Power { get; private set; }

        [JsonProperty("Cost")] public long Cost { get; private set; }
    }

    public partial class PowerplayFastTrackEvent
    {
        public static PowerplayFastTrackEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PowerplayFastTrackEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<PowerplayFastTrackEvent> PowerplayFastTrackEvent;

    }
}