using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class ScannedEvent : EventBase
    {
        internal ScannedEvent()
        {
        }

        [JsonProperty("ScanType")] public string ScanType { get; private set; }
    }

    public partial class ScannedEvent
    {
        public static ScannedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ScannedEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<ScannedEvent> ScannedEvent;

    }
}