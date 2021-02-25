using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class DataScannedEvent : EventBase
    {
        internal DataScannedEvent()
        {
        }

        [JsonProperty("Type")] public string Type { get; private set; }
    }

    public partial class DataScannedEvent
    {
        public static DataScannedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<DataScannedEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<DataScannedEvent> DataScannedEvent;

    }
}