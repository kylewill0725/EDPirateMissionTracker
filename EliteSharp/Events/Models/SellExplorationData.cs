using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class SellExplorationData : EventBase
    {
        [DataMember(Name = "Systems")] public string[] Systems { get; set; }

        [DataMember(Name = "Discovered")] public string[] Discovered { get; set; }

        [DataMember(Name = "BaseValue")] public long BaseValue { get; set; }

        [DataMember(Name = "Bonus")] public long Bonus { get; set; }

        [DataMember(Name = "TotalEarnings")] public long TotalEarnings { get; set; }
    }
}