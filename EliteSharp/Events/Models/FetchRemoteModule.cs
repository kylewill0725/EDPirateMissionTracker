using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class FetchRemoteModule : EventBase
    {
        public enum ShipEnum
        {
            [DataMember(Name = "anaconda")] Anaconda,
            [DataMember(Name = "asp")] Asp
        }

        [DataMember(Name = "StorageSlot")] public long StorageSlot { get; set; }

        [DataMember(Name = "StoredItem")] public string StoredItem { get; set; }

        [DataMember(Name = "StoredItem_Localised")]
        public string StoredItemLocalised { get; set; }

        [DataMember(Name = "ServerId")] public long ServerId { get; set; }

        [DataMember(Name = "TransferCost")] public long TransferCost { get; set; }

        [DataMember(Name = "TransferTime")] public long TransferTime { get; set; }

        [DataMember(Name = "Ship")] public ShipEnum Ship { get; set; }

        [DataMember(Name = "ShipID")] public long ShipId { get; set; }
    }
}