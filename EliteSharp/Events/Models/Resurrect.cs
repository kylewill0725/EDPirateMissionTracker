using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class Resurrect : EventBase
    {
        public enum OptionEnum
        {
            [DataMember(Name = "rebuy")] Rebuy
        }

        [DataMember(Name = "Option")] public OptionEnum Option { get; set; }

        [DataMember(Name = "Cost")] public long Cost { get; set; }

        [DataMember(Name = "Bankrupt")] public bool Bankrupt { get; set; }
    }
}