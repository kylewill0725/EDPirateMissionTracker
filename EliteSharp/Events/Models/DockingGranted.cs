using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class DockingGranted : EventBase
    {
        public enum StationTypeEnum
        {
            [DataMember(Name = "Coriolis")] Coriolis,
            [DataMember(Name = "CraterOutpost")] CraterOutpost,
            [DataMember(Name = "CraterPort")] CraterPort,
            [DataMember(Name = "FleetCarrier")] FleetCarrier,
            [DataMember(Name = "Ocellus")] Ocellus,
            [DataMember(Name = "Orbis")] Orbis,
            [DataMember(Name = "Outpost")] Outpost
        }

        [DataMember(Name = "LandingPad")] public long LandingPad { get; set; }

        [DataMember(Name = "MarketID")] public long MarketId { get; set; }

        [DataMember(Name = "StationName")] public string StationName { get; set; }

        [DataMember(Name = "StationType")] public StationTypeEnum StationType { get; set; }
    }
}