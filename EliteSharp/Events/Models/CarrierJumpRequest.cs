using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class CarrierJumpRequest : EventBase
    {
        [DataMember(Name = "CarrierID")] public long CarrierId { get; set; }

        [DataMember(Name = "SystemName")] public string SystemName { get; set; }

        [DataMember(Name = "Body", IsRequired = false)]
        public string? Body { get; set; }

        [DataMember(Name = "SystemAddress")] public long SystemAddress { get; set; }

        [DataMember(Name = "BodyID")] public long BodyId { get; set; }
    }
}