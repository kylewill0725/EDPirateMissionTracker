using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class Touchdown : EventBase
    {
        [DataMember(Name = "PlayerControlled")]
        public bool PlayerControlled { get; set; }

        [DataMember(Name = "Latitude", IsRequired = false)]
        public double? Latitude { get; set; }

        [DataMember(Name = "Longitude", IsRequired = false)]
        public double? Longitude { get; set; }

        [DataMember(Name = "NearestDestination", IsRequired = false)]
        public string? NearestDestination { get; set; }

        [DataMember(Name = "NearestDestination_Localised", IsRequired = false)]
        public string? NearestDestinationLocalised { get; set; }
    }
}