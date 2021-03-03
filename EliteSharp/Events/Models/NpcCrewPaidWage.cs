using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class NpcCrewPaidWage : EventBase
    {
        [DataMember(Name = "NpcCrewName")] public string NpcCrewName { get; set; }

        [DataMember(Name = "NpcCrewId")] public long NpcCrewId { get; set; }

        [DataMember(Name = "Amount")] public long Amount { get; set; }
    }
}