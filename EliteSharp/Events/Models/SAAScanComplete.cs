using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class SaaScanComplete : EventBase
    {
        [DataMember(Name = "BodyName")] public string BodyName { get; set; }

        [DataMember(Name = "SystemAddress")] public long SystemAddress { get; set; }

        [DataMember(Name = "BodyID")] public long BodyId { get; set; }

        [DataMember(Name = "ProbesUsed")] public long ProbesUsed { get; set; }

        [DataMember(Name = "EfficiencyTarget")]
        public long EfficiencyTarget { get; set; }
    }
}