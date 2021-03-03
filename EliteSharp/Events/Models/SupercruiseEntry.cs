using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class SupercruiseEntry : EventBase
    {
        [DataMember(Name = "StarSystem")] public string StarSystem { get; set; }

        [DataMember(Name = "SystemAddress")] public long SystemAddress { get; set; }
    }
}