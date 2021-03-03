using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class ShipyardTransfer : EventBase
    {
        [DataMember(Name = "ShipType")] public string ShipType { get; set; }

        [DataMember(Name = "ShipType_Localised", IsRequired = false)]
        public string? ShipTypeLocalised { get; set; }

        [DataMember(Name = "ShipID")] public long ShipId { get; set; }

        [DataMember(Name = "System")] public string System { get; set; }

        [DataMember(Name = "ShipMarketID")] public long ShipMarketId { get; set; }

        [DataMember(Name = "Distance")] public double Distance { get; set; }

        [DataMember(Name = "TransferPrice")] public long TransferPrice { get; set; }

        [DataMember(Name = "TransferTime")] public long TransferTime { get; set; }

        [DataMember(Name = "MarketID")] public long MarketId { get; set; }
    }
}