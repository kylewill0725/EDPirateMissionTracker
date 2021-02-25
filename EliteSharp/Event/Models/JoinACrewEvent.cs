using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class JoinACrewEvent : EventBase
    {
        internal JoinACrewEvent()
        {
        }

        [JsonProperty("Captain")] public string Captain { get; private set; }
    }

    public partial class JoinACrewEvent
    {
        public static JoinACrewEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<JoinACrewEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<JoinACrewEvent> JoinACrewEvent;

    }
}