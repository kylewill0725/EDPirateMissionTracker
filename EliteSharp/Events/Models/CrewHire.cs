using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class CrewHire : EventBase
    {
        [DataMember(Name = "Name")] public string Name { get; set; }

        [DataMember(Name = "CrewID")] public long CrewId { get; set; }

        [DataMember(Name = "Faction")] public string Faction { get; set; }

        [DataMember(Name = "Cost")] public long Cost { get; set; }

        [DataMember(Name = "CombatRank")] public long CombatRank { get; set; }
    }
}