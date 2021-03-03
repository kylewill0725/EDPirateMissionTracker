using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class StartJump : EventBase
    {
        [DataMember(Name = "JumpType")] public string JumpType { get; set; }

        [DataMember(Name = "StarSystem", IsRequired = false)]
        public string? StarSystem { get; set; }

        [DataMember(Name = "SystemAddress", IsRequired = false)]
        public long? SystemAddress { get; set; }

        [DataMember(Name = "StarClass", IsRequired = false)]
        public string? StarClass { get; set; }
    }
}