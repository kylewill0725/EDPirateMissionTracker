using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class UnderAttack : EventBase
    {
        public enum TargetEnum
        {
            [DataMember(Name = "Fighter")] Fighter,
            [DataMember(Name = "Mothership")] Mothership,
            [DataMember(Name = "You")] You
        }

        [DataMember(Name = "Target")] public TargetEnum Target { get; set; }
    }
}