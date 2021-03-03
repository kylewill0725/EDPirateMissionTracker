using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class UnderAttack : EventBase
    {
        [DataMember(Name = "Target")] public string Target { get; set; }
    }
}