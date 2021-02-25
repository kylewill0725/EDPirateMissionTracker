using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class CrewMemberRoleChangeEvent : EventBase
    {
        internal CrewMemberRoleChangeEvent()
        {
        }

        [JsonProperty("Crew")] public string Crew { get; private set; }

        [JsonProperty("Role")] public string Role { get; private set; }
    }

    public partial class CrewMemberRoleChangeEvent
    {
        public static CrewMemberRoleChangeEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CrewMemberRoleChangeEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<CrewMemberRoleChangeEvent> CrewMemberRoleChangeEvent;

    }
}