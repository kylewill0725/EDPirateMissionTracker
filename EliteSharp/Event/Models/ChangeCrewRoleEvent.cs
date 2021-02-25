using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class ChangeCrewRoleEvent : EventBase
    {
        internal ChangeCrewRoleEvent()
        {
        }

        [JsonProperty("Role")] public string Role { get; private set; }
    }

    public partial class ChangeCrewRoleEvent
    {
        public static ChangeCrewRoleEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ChangeCrewRoleEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<ChangeCrewRoleEvent> ChangeCrewRoleEvent;

    }
}