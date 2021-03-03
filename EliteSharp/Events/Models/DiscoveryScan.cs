using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class DiscoveryScan : EventBase
    {
        [DataMember(Name = "SystemAddress")] public long SystemAddress { get; set; }

        [DataMember(Name = "Bodies")] public long Bodies { get; set; }
    }
}