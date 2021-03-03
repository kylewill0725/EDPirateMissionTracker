using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class SupercruiseExit : EventBase
    {
        [DataMember(Name = "StarSystem")] public string StarSystem { get; set; }

        [DataMember(Name = "SystemAddress")] public long SystemAddress { get; set; }

        [DataMember(Name = "Body")] public string Body { get; set; }

        [DataMember(Name = "BodyID")] public long BodyId { get; set; }

        [DataMember(Name = "BodyType")] public string BodyType { get; set; }
    }
}