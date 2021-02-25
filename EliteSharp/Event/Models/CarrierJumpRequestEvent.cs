using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class CarrierJumpRequestEvent : EventBase
    {
        internal CarrierJumpRequestEvent()
        {
        }

        [JsonProperty("CarrierID")] public long CarrierId { get; private set; }

        [JsonProperty("SystemName")] public string SystemName { get; private set; }

        [JsonProperty("Body")] public string Body { get; private set; }

        [JsonProperty("SystemAddress")] public long SystemAddress { get; private set; }

        [JsonProperty("BodyID")] public long BodyId { get; private set; }
    }

    public partial class CarrierJumpRequestEvent
    {
        public static CarrierJumpRequestEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CarrierJumpRequestEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<CarrierJumpRequestEvent> CarrierJumpRequestEvent;

    }
}