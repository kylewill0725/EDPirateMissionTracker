using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class MissionAbandonedEvent : EventBase
    {
        internal MissionAbandonedEvent()
        {
        }

        [JsonProperty("Name")] public string Name { get; private set; }

        [JsonProperty("MissionID")] public long MissionId { get; private set; }
    }

    public partial class MissionAbandonedEvent
    {
        public static MissionAbandonedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MissionAbandonedEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<MissionAbandonedEvent> MissionAbandonedEvent;

    }
}