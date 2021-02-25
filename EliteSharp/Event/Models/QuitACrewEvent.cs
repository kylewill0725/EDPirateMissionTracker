using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class QuitACrewEvent : EventBase
    {
        internal QuitACrewEvent()
        {
        }

        [JsonProperty("Captain")] public string Captain { get; private set; }
    }

    public partial class QuitACrewEvent
    {
        public static QuitACrewEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<QuitACrewEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<QuitACrewEvent> QuitACrewEvent;

    }
}