using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class WingInviteEvent : EventBase
    {
        internal WingInviteEvent()
        {
        }

        [JsonProperty("Name")] public string Name { get; private set; }
    }

    public partial class WingInviteEvent
    {
        public static WingInviteEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<WingInviteEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<WingInviteEvent> WingInviteEvent;

    }
}