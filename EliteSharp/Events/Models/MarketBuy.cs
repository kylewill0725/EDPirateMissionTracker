using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class MarketBuy : EventBase
    {
        [DataMember(Name = "MarketID")] public long MarketId { get; set; }

        [DataMember(Name = "Type")] public string Type { get; set; }

        [DataMember(Name = "Type_Localised", IsRequired = false)]
        public string? TypeLocalised { get; set; }

        [DataMember(Name = "Count")] public long Count { get; set; }

        [DataMember(Name = "BuyPrice")] public long BuyPrice { get; set; }

        [DataMember(Name = "TotalCost")] public long TotalCost { get; set; }
    }
}