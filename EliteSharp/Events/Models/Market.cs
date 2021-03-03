using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class Market : EventBase
    {
        public enum CarrierDockingAccessEnum
        {
            [DataMember(Name = "all")] All
        }

        public enum StationTypeEnum
        {
            [DataMember(Name = "Bernal")] Bernal,
            [DataMember(Name = "Coriolis")] Coriolis,
            [DataMember(Name = "CraterOutpost")] CraterOutpost,
            [DataMember(Name = "FleetCarrier")] FleetCarrier,
            [DataMember(Name = "Orbis")] Orbis,
            [DataMember(Name = "Outpost")] Outpost
        }

        [DataMember(Name = "MarketID")] public long MarketId { get; set; }

        [DataMember(Name = "StationName")] public string StationName { get; set; }

        [DataMember(Name = "StationType")] public StationTypeEnum StationType { get; set; }

        [DataMember(Name = "StarSystem")] public string StarSystem { get; set; }

        [DataMember(Name = "CarrierDockingAccess", IsRequired = false)]
        public CarrierDockingAccessEnum? CarrierDockingAccess { get; set; }
    }
}