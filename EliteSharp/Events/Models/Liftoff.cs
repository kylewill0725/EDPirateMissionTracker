using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class Liftoff : EventBase
    {
        [DataMember(Name = "PlayerControlled")]
        public bool PlayerControlled { get; set; }

        [DataMember(Name = "NearestDestination", IsRequired = false)]
        public string? NearestDestination { get; set; }

        [DataMember(Name = "NearestDestination_Localised", IsRequired = false)]
        public string? NearestDestinationLocalised { get; set; }

        [DataMember(Name = "Latitude")] public double Latitude { get; set; }

        [DataMember(Name = "Longitude")] public double Longitude { get; set; }
    }
}