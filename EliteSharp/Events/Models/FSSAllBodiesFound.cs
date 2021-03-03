using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class FssAllBodiesFound : EventBase
    {
        [DataMember(Name = "SystemName")] public string SystemName { get; set; }

        [DataMember(Name = "SystemAddress")] public long SystemAddress { get; set; }

        [DataMember(Name = "Count")] public long Count { get; set; }
    }
}