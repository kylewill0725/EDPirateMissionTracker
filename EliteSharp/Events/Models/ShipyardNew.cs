using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class ShipyardNew : EventBase
    {
        [DataMember(Name = "ShipType")] public string ShipType { get; set; }

        [DataMember(Name = "NewShipID")] public long NewShipId { get; set; }

        [DataMember(Name = "ShipType_Localised", IsRequired = false)]
        public string? ShipTypeLocalised { get; set; }
    }
}