using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class MissionRedirectedEvent : EventBase
    {
        internal MissionRedirectedEvent()
        {
        }

        [JsonProperty("MissionID")] public long MissionId { get; private set; }

        [JsonProperty("Name")] public string Name { get; private set; }

        [JsonProperty("NewDestinationStation")]
        public string NewDestinationStation { get; private set; }

        [JsonProperty("NewDestinationSystem")] public string NewDestinationSystem { get; private set; }

        [JsonProperty("OldDestinationStation")]
        public string OldDestinationStation { get; private set; }

        [JsonProperty("OldDestinationSystem")] public string OldDestinationSystem { get; private set; }
    }

    public partial class MissionRedirectedEvent
    {
        public static MissionRedirectedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MissionRedirectedEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<MissionRedirectedEvent> MissionRedirectedEvent;

    }
}