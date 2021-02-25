using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class WingAddEvent : EventBase
    {
        internal WingAddEvent()
        {
        }

        [JsonProperty("Name")] public string Name { get; private set; }
    }

    public partial class WingAddEvent
    {
        public static WingAddEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<WingAddEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<WingAddEvent> WingAddEvent;

    }
}