using System.Runtime.Serialization;
using EliteSharp.GameModel;

namespace EliteSharp.Events.Models
{
    public class ShipyardSwap : EventBase
    {
        [DataMember(Name = "ShipType")] public ShipTypeEnum ShipType { get; set; }

        [DataMember(Name = "ShipID")] public long ShipId { get; set; }

        [DataMember(Name = "StoreOldShip")] public ShipTypeEnum StoreOldShip { get; set; }

        [DataMember(Name = "StoreShipID")] public long StoreShipId { get; set; }

        [DataMember(Name = "MarketID")] public long MarketId { get; set; }

        [DataMember(Name = "ShipType_Localised", IsRequired = false)]
        public ShipTypeLocalisedEnum? ShipTypeLocalised { get; set; }
    }
}