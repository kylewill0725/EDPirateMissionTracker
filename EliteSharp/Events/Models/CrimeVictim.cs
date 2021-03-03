using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class CrimeVictim : EventBase
    {
        public enum CrimeTypeEnum
        {
            [DataMember(Name = "assault")] Assault,
            [DataMember(Name = "interdiction")] Interdiction
        }

        [DataMember(Name = "Offender")] public string Offender { get; set; }

        [DataMember(Name = "CrimeType")] public CrimeTypeEnum CrimeType { get; set; }

        [DataMember(Name = "Fine", IsRequired = false)]
        public long? Fine { get; set; }

        [DataMember(Name = "Bounty", IsRequired = false)]
        public long? Bounty { get; set; }
    }
}