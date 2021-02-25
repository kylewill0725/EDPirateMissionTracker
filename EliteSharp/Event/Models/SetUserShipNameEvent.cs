using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class SetUserShipNameEvent : EventBase
    {
        internal SetUserShipNameEvent()
        {
        }

        [JsonProperty("Ship")] public string Ship { get; private set; }

        [JsonProperty("ShipID")] public long ShipId { get; private set; }

        [JsonProperty("UserShipName")] public string UserShipName { get; private set; }

        [JsonProperty("UserShipId")] public string UserShipId { get; private set; }
    }

    public partial class SetUserShipNameEvent
    {
        public static SetUserShipNameEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SetUserShipNameEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<SetUserShipNameEvent> SetUserShipNameEvent;

    }
}