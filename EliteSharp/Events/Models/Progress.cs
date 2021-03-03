using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class Progress : EventBase
    {
        [DataMember(Name = "Combat")] public long Combat { get; set; }

        [DataMember(Name = "Trade")] public long Trade { get; set; }

        [DataMember(Name = "Explore")] public long Explore { get; set; }

        [DataMember(Name = "Empire")] public long Empire { get; set; }

        [DataMember(Name = "Federation")] public long Federation { get; set; }

        [DataMember(Name = "CQC")] public long Cqc { get; set; }
    }
}