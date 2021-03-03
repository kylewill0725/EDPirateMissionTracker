using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class ModuleBuy : EventBase
    {
        [DataMember(Name = "Slot")] public string Slot { get; set; }

        [DataMember(Name = "BuyItem")] public string BuyItem { get; set; }

        [DataMember(Name = "BuyItem_Localised")]
        public string BuyItemLocalised { get; set; }

        [DataMember(Name = "MarketID")] public long MarketId { get; set; }

        [DataMember(Name = "BuyPrice")] public long BuyPrice { get; set; }

        [DataMember(Name = "Ship")] public string Ship { get; set; }

        [DataMember(Name = "ShipID")] public long ShipId { get; set; }

        [DataMember(Name = "SellItem", IsRequired = false)]
        public string? SellItem { get; set; }

        [DataMember(Name = "SellItem_Localised", IsRequired = false)]
        public string? SellItemLocalised { get; set; }

        [DataMember(Name = "SellPrice", IsRequired = false)]
        public long? SellPrice { get; set; }

        [DataMember(Name = "StoredItem", IsRequired = false)]
        public string? StoredItem { get; set; }

        [DataMember(Name = "StoredItem_Localised", IsRequired = false)]
        public string? StoredItemLocalised { get; set; }
    }
}