using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class ApproachSettlementEvent : EventBase
    {
        internal ApproachSettlementEvent()
        {
        }

        [JsonProperty("Name")] public string Name { get; private set; }

        [JsonProperty("MarketID")] public long MarketId { get; private set; }

        [JsonProperty("SystemAddress")] public long SystemAddress { get; private set; }

        [JsonProperty("BodyID")] public long BodyId { get; private set; }

        [JsonProperty("BodyName")] public string BodyName { get; private set; }

        [JsonProperty("Latitude")] public double Latitude { get; private set; }

        [JsonProperty("Longitude")] public double Longitude { get; private set; }
    }

    public partial class ApproachSettlementEvent
    {
        public static ApproachSettlementEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ApproachSettlementEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<ApproachSettlementEvent> ApproachSettlementEvent;

    }
}