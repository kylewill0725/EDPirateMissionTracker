using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class ReceiveTextEvent : EventBase
    {
        internal ReceiveTextEvent()
        {
        }

        [JsonProperty("From")] public string From { get; private set; }

        [JsonProperty("Message")] public string Message { get; private set; }

        [JsonProperty("Message_Localised")] public string MessageLocalised { get; private set; }

        [JsonProperty("Channel")] public string Channel { get; private set; }
    }

    public partial class ReceiveTextEvent
    {
        public static ReceiveTextEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ReceiveTextEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<ReceiveTextEvent> ReceiveTextEvent;

    }
}