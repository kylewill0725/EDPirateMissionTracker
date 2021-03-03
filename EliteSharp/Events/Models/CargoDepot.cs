using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class CargoDepot : EventBase
    {
        public enum UpdateTypeEnum
        {
            [DataMember(Name = "Collect")] Collect,
            [DataMember(Name = "Deliver")] Deliver,
            [DataMember(Name = "WingUpdate")] WingUpdate
        }

        [DataMember(Name = "MissionID")] public long MissionId { get; set; }

        [DataMember(Name = "UpdateTypeEnum")] public UpdateTypeEnum UpdateType { get; set; }

        [DataMember(Name = "StartMarketID")] public long StartMarketId { get; set; }

        [DataMember(Name = "EndMarketID")] public long EndMarketId { get; set; }

        [DataMember(Name = "ItemsCollected")] public long ItemsCollected { get; set; }

        [DataMember(Name = "ItemsDelivered")] public long ItemsDelivered { get; set; }

        [DataMember(Name = "TotalItemsToDeliver")]
        public long TotalItemsToDeliver { get; set; }

        [DataMember(Name = "Progress")] public double Progress { get; set; }

        [DataMember(Name = "CargoType", IsRequired = false)]
        public string? CargoType { get; set; }

        [DataMember(Name = "CargoType_Localised", IsRequired = false)]
        public string? CargoTypeLocalised { get; set; }

        [DataMember(Name = "Count", IsRequired = false)]
        public long? Count { get; set; }
    }
}