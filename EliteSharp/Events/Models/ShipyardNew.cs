using System.Runtime.Serialization;
using EliteSharp.GameModel;

namespace EliteSharp.Events.Models
{
    public class ShipyardNew : EventBase
    {
        [DataMember(Name = "ShipType")] public ShipTypeEnum ShipType { get; set; }

        [DataMember(Name = "NewShipID")] public long NewShipId { get; set; }

        [DataMember(Name = "ShipType_Localised", IsRequired = false)]
        public ShipTypeLocalisedEnum? ShipTypeLocalised { get; set; }
    }
}