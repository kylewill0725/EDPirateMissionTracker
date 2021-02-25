using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class LaunchSrvEvent : EventBase
    {
        internal LaunchSrvEvent()
        {
        }

        [JsonProperty("Loadout")] public string Loadout { get; private set; }

        [JsonProperty("ID")] public long Id { get; private set; }

        [JsonProperty("PlayerControlled")] public bool PlayerControlled { get; private set; }
    }

    public partial class LaunchSrvEvent
    {
        public static LaunchSrvEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<LaunchSrvEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<LaunchSrvEvent> LaunchSrvEvent;

    }
}