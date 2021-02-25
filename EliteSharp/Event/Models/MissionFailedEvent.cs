using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class MissionFailedEvent : EventBase
    {
        internal MissionFailedEvent()
        {
        }

        [JsonProperty("Name")] public string Name { get; private set; }

        [JsonProperty("MissionID")] public long MissionId { get; private set; }
    }

    public partial class MissionFailedEvent
    {
        public static MissionFailedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MissionFailedEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<MissionFailedEvent> MissionFailedEvent;

    }
}