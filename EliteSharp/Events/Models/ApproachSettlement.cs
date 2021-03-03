using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class ApproachSettlement : EventBase
    {
        [DataMember(Name = "Name")] public string Name { get; set; }

        [DataMember(Name = "MarketID", IsRequired = false)]
        public long? MarketId { get; set; }

        [DataMember(Name = "SystemAddress")] public long SystemAddress { get; set; }

        [DataMember(Name = "BodyID")] public long BodyId { get; set; }

        [DataMember(Name = "BodyName")] public string BodyName { get; set; }

        [DataMember(Name = "Latitude", IsRequired = false)]
        public double? Latitude { get; set; }

        [DataMember(Name = "Longitude", IsRequired = false)]
        public double? Longitude { get; set; }
    }
}