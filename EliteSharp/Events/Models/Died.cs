using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class Died : EventBase
    {
        [DataMember(Name = "KillerName", IsRequired = false)]
        public string? KillerName { get; set; }

        [DataMember(Name = "KillerShip", IsRequired = false)]
        public string? KillerShip { get; set; }

        [DataMember(Name = "KillerRank", IsRequired = false)]
        public string? KillerRank { get; set; }
    }
}