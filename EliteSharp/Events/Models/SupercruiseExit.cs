using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class SupercruiseExit : EventBase
    {
        public enum BodyTypeEnum
        {
            [DataMember(Name = "AsteroidCluster")] AsteroidCluster,
            [DataMember(Name = "Null")] Null,
            [DataMember(Name = "Planet")] Planet,
            [DataMember(Name = "PlanetaryRing")] PlanetaryRing,
            [DataMember(Name = "Star")] Star,
            [DataMember(Name = "Station")] Station
        }

        [DataMember(Name = "StarSystem")] public string StarSystem { get; set; }

        [DataMember(Name = "SystemAddress")] public long SystemAddress { get; set; }

        [DataMember(Name = "Body")] public string Body { get; set; }

        [DataMember(Name = "BodyID")] public long BodyId { get; set; }

        [DataMember(Name = "BodyType")] public BodyTypeEnum BodyType { get; set; }
    }
}