using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class HullDamage : EventBase
    {
        [DataMember(Name = "Health")] public double Health { get; set; }

        [DataMember(Name = "PlayerPilot")] public bool PlayerPilot { get; set; }

        [DataMember(Name = "Fighter", IsRequired = false)]
        public bool? Fighter { get; set; }
    }
}