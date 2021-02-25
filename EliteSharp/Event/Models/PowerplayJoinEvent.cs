using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class PowerplayJoinEvent : EventBase
    {
        internal PowerplayJoinEvent()
        {
        }

        [JsonProperty("Power")] public string Power { get; private set; }
    }

    public partial class PowerplayJoinEvent
    {
        public static PowerplayJoinEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PowerplayJoinEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<PowerplayJoinEvent> PowerplayJoinEvent;

    }
}