using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class Interdiction : EventBase
    {
        [DataMember(Name = "Success")] public bool Success { get; set; }

        [DataMember(Name = "IsPlayer")] public bool IsPlayer { get; set; }

        [DataMember(Name = "Faction")] public string Faction { get; set; }
    }
}