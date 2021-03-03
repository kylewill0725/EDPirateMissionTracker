using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class BuyDrones : EventBase
    {
        public enum TypeEnum
        {
            [DataMember(Name = "Drones")] Drones
        }

        [DataMember(Name = "Type")] public TypeEnum Type { get; set; }

        [DataMember(Name = "Count")] public long Count { get; set; }

        [DataMember(Name = "BuyPrice")] public long BuyPrice { get; set; }

        [DataMember(Name = "TotalCost")] public long TotalCost { get; set; }
    }
}