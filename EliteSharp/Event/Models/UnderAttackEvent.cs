using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class UnderAttackEvent : EventBase
    {
        internal UnderAttackEvent()
        {
        }

        [JsonProperty("Target")] public string Target { get; private set; }
    }

    public partial class UnderAttackEvent
    {
        public static UnderAttackEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<UnderAttackEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<UnderAttackEvent> UnderAttackEvent;

    }
}