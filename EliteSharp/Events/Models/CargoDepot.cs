using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class CargoDepot : EventBase
    {
        [DataMember(Name = "MissionID")] public long MissionId { get; set; }

        [DataMember(Name = "UpdateType")] public string UpdateType { get; set; }

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