using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class CommitCrime : EventBase
    {
        [DataMember(Name = "CrimeType")] public string CrimeType { get; set; }

        [DataMember(Name = "Faction")] public string Faction { get; set; }

        [DataMember(Name = "Fine", IsRequired = false)]
        public long? Fine { get; set; }

        [DataMember(Name = "Victim", IsRequired = false)]
        public string? Victim { get; set; }

        [DataMember(Name = "Bounty", IsRequired = false)]
        public long? Bounty { get; set; }

        [DataMember(Name = "Victim_Localised", IsRequired = false)]
        public string? VictimLocalised { get; set; }
    }
}