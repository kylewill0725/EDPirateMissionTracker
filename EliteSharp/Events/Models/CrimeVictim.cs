using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class CrimeVictim : EventBase
    {
        [DataMember(Name = "Offender")] public string Offender { get; set; }

        [DataMember(Name = "CrimeType")] public string CrimeType { get; set; }

        [DataMember(Name = "Fine", IsRequired = false)]
        public long? Fine { get; set; }

        [DataMember(Name = "Bounty", IsRequired = false)]
        public long? Bounty { get; set; }
    }
}