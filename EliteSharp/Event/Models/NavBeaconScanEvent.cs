using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class NavBeaconScanEvent : EventBase
    {
        internal NavBeaconScanEvent()
        {
        }

        [JsonProperty("NumBodies")] public long NumBodies { get; private set; }
    }

    public partial class NavBeaconScanEvent
    {
        public static NavBeaconScanEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<NavBeaconScanEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<NavBeaconScanEvent> NavBeaconScanEvent;

    }
}