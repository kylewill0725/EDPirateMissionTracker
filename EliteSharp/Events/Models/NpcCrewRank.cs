using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class NpcCrewRank : EventBase
    {
        [DataMember(Name = "NpcCrewName")] public string NpcCrewName { get; set; }

        [DataMember(Name = "NpcCrewId")] public long NpcCrewId { get; set; }

        [DataMember(Name = "RankCombat")] public long RankCombat { get; set; }
    }
}