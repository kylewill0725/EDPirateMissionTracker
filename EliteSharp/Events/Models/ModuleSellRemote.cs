using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class ModuleSellRemote : EventBase
    {
        [DataMember(Name = "StorageSlot")] public long StorageSlot { get; set; }

        [DataMember(Name = "SellItem")] public string SellItem { get; set; }

        [DataMember(Name = "SellItem_Localised")]
        public string SellItemLocalised { get; set; }

        [DataMember(Name = "ServerId")] public long ServerId { get; set; }

        [DataMember(Name = "SellPrice")] public long SellPrice { get; set; }

        [DataMember(Name = "Ship")] public string Ship { get; set; }

        [DataMember(Name = "ShipID")] public long ShipId { get; set; }
    }
}