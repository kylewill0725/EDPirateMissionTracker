using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class SellDrones : EventBase
    {
        public enum TypeEnum
        {
            [DataMember(Name = "Drones")] Drones
        }

        [DataMember(Name = "Type")] public TypeEnum Type { get; set; }

        [DataMember(Name = "Count")] public long Count { get; set; }

        [DataMember(Name = "SellPrice")] public long SellPrice { get; set; }

        [DataMember(Name = "TotalSale")] public long TotalSale { get; set; }
    }
}