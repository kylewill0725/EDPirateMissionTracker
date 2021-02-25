using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class DatalinkScanEvent : EventBase
    {
        internal DatalinkScanEvent()
        {
        }

        [JsonProperty("Message")] public string Message { get; private set; }

        [JsonProperty("Message_Localised")] public string MessageLocalised { get; private set; }
    }

    public partial class DatalinkScanEvent
    {
        public static DatalinkScanEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<DatalinkScanEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<DatalinkScanEvent> DatalinkScanEvent;

    }
}