using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class ShipyardSell : EventBase
    {
        [DataMember(Name = "ShipType")] public string ShipType { get; set; }

        [DataMember(Name = "SellShipID")] public long SellShipId { get; set; }

        [DataMember(Name = "ShipPrice")] public long ShipPrice { get; set; }

        [DataMember(Name = "System", IsRequired = false)]
        public string? System { get; set; }

        [DataMember(Name = "ShipMarketID", IsRequired = false)]
        public long? ShipMarketId { get; set; }

        [DataMember(Name = "MarketID")] public long MarketId { get; set; }
    }
}