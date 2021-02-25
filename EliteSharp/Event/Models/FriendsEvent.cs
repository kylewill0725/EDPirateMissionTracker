using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class FriendsEvent : EventBase
    {
        internal FriendsEvent()
        {
        }

        [JsonProperty("Status")] public string Status { get; private set; }

        [JsonProperty("Name")] public string Name { get; private set; }
    }

    public partial class FriendsEvent
    {
        public static FriendsEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<FriendsEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<FriendsEvent> FriendsEvent;

    }
}