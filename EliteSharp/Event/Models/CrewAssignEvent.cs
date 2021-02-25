using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class CrewAssignEvent : EventBase
    {
        internal CrewAssignEvent()
        {
        }

        [JsonProperty("Name")] public string Name { get; private set; }

        [JsonProperty("CrewID")] public long CrewId { get; private set; }

        [JsonProperty("Role")] public string Role { get; private set; }
    }

    public partial class CrewAssignEvent
    {
        public static CrewAssignEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CrewAssignEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<CrewAssignEvent> CrewAssignEvent;

    }
}