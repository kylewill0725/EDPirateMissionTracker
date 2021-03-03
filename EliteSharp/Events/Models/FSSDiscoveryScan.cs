using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class FssDiscoveryScan : EventBase
    {
        [DataMember(Name = "Progress")] public double Progress { get; set; }

        [DataMember(Name = "BodyCount")] public long BodyCount { get; set; }

        [DataMember(Name = "NonBodyCount")] public long NonBodyCount { get; set; }

        [DataMember(Name = "SystemName")] public string SystemName { get; set; }

        [DataMember(Name = "SystemAddress")] public long SystemAddress { get; set; }
    }
}