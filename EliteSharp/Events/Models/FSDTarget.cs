using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class FsdTarget : EventBase
    {
        [DataMember(Name = "Name")] public string Name { get; set; }

        [DataMember(Name = "SystemAddress")] public long SystemAddress { get; set; }

        [DataMember(Name = "StarClass")] public string StarClass { get; set; }

        [DataMember(Name = "RemainingJumpsInRoute", IsRequired = false)]
        public long? RemainingJumpsInRoute { get; set; }
    }
}