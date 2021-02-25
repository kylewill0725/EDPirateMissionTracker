using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class EndCrewSessionEvent : EventBase
    {
        internal EndCrewSessionEvent()
        {
        }

        [JsonProperty("OnCrime")] public bool OnCrime { get; private set; }
    }

    public partial class EndCrewSessionEvent
    {
        public static EndCrewSessionEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<EndCrewSessionEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<EndCrewSessionEvent> EndCrewSessionEvent;

    }
}