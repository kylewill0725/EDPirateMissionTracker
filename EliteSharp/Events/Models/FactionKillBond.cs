using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class FactionKillBond : EventBase
    {
        [DataMember(Name = "Reward")] public long Reward { get; set; }

        [DataMember(Name = "AwardingFaction")] public string AwardingFaction { get; set; }

        [DataMember(Name = "VictimFaction")] public string VictimFaction { get; set; }
    }
}