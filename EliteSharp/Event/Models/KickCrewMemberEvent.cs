using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class KickCrewMemberEvent : EventBase
    {
        internal KickCrewMemberEvent()
        {
        }

        [JsonProperty("Crew")] public string Crew { get; private set; }

        [JsonProperty("OnCrime")] public bool OnCrime { get; private set; }
    }

    public partial class KickCrewMemberEvent
    {
        public static KickCrewMemberEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<KickCrewMemberEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<KickCrewMemberEvent> KickCrewMemberEvent;

    }
}