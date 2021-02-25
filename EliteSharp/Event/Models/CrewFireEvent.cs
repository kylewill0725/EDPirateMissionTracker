using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class CrewFireEvent : EventBase
    {
        internal CrewFireEvent()
        {
        }

        [JsonProperty("Name")] public string Name { get; private set; }
    }

    public partial class CrewFireEvent
    {
        public static CrewFireEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CrewFireEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<CrewFireEvent> CrewFireEvent;

    }
}