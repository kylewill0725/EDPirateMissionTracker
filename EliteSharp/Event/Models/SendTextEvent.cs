using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class SendTextEvent : EventBase
    {
        internal SendTextEvent()
        {
        }

        [JsonProperty("To")] public string To { get; private set; }

        [JsonProperty("Message")] public string Message { get; private set; }

        [JsonProperty("Sent")] public bool Sent { get; private set; }
    }

    public partial class SendTextEvent
    {
        public static SendTextEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SendTextEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<SendTextEvent> SendTextEvent;

    }
}