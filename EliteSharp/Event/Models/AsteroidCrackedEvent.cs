using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class AsteroidCrackedEvent : EventBase
    {
        internal AsteroidCrackedEvent()
        {
        }

        [JsonProperty("Body")] public string Body { get; private set; }
    }

    public partial class AsteroidCrackedEvent
    {
        public static AsteroidCrackedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<AsteroidCrackedEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<AsteroidCrackedEvent> AsteroidCrackedEvent;

    }
}