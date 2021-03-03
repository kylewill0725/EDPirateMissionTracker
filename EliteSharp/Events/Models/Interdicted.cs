using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class Interdicted : EventBase
    {
        [DataMember(Name = "Submitted")] public bool Submitted { get; set; }

        [DataMember(Name = "Interdictor")] public string Interdictor { get; set; }

        [DataMember(Name = "IsPlayer")] public bool IsPlayer { get; set; }

        [DataMember(Name = "Faction")] public string Faction { get; set; }
    }
}