using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class MarketSell : EventBase
    {
        [DataMember(Name = "MarketID")] public long MarketId { get; set; }

        [DataMember(Name = "Type")] public string Type { get; set; }

        [DataMember(Name = "Count")] public long Count { get; set; }

        [DataMember(Name = "SellPrice")] public long SellPrice { get; set; }

        [DataMember(Name = "TotalSale")] public long TotalSale { get; set; }

        [DataMember(Name = "AvgPricePaid")] public long AvgPricePaid { get; set; }

        [DataMember(Name = "Type_Localised", IsRequired = false)]
        public string? TypeLocalised { get; set; }

        [DataMember(Name = "StolenGoods", IsRequired = false)]
        public bool? StolenGoods { get; set; }

        [DataMember(Name = "BlackMarket", IsRequired = false)]
        public bool? BlackMarket { get; set; }
    }
}