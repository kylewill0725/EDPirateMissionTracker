using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class ShipyardNewEvent : EventBase
    {
        internal ShipyardNewEvent()
        {
        }

        [JsonProperty("ShipType")] public string ShipType { get; private set; }

        [JsonProperty("ShipType_Localised")] public string ShipTypeLocalised { get; private set; }

        [JsonProperty("NewShipID")] public long NewShipId { get; private set; }
    }

    public partial class ShipyardNewEvent
    {
        public static ShipyardNewEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ShipyardNewEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<ShipyardNewEvent> ShipyardNewEvent;

    }
}