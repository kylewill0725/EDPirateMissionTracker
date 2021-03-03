using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class Resurrect : EventBase
    {
        [DataMember(Name = "Option")] public string Option { get; set; }

        [DataMember(Name = "Cost")] public long Cost { get; set; }

        [DataMember(Name = "Bankrupt")] public bool Bankrupt { get; set; }
    }
}