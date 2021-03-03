using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class PvpKill : EventBase
    {
        [DataMember(Name = "Victim")] public string Victim { get; set; }

        [DataMember(Name = "CombatRank")] public long CombatRank { get; set; }
    }
}