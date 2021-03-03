using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class ModuleBuy : EventBase
    {
        public enum ShipEnum
        {
            [DataMember(Name = "anaconda")] Anaconda,
            [DataMember(Name = "asp")] Asp,
            [DataMember(Name = "eagle")] Eagle,
            [DataMember(Name = "python")] Python,
            [DataMember(Name = "type7")] Type7,
            [DataMember(Name = "type9")] Type9,
            [DataMember(Name = "vulture")] Vulture
        }

        [DataMember(Name = "Slot")] public string Slot { get; set; }

        [DataMember(Name = "BuyItem")] public string BuyItem { get; set; }

        [DataMember(Name = "BuyItem_Localised")]
        public string BuyItemLocalised { get; set; }

        [DataMember(Name = "MarketID")] public long MarketId { get; set; }

        [DataMember(Name = "BuyPrice")] public long BuyPrice { get; set; }

        [DataMember(Name = "Ship")] public ShipEnum Ship { get; set; }

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