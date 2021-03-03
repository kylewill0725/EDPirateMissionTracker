using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class DockingDenied : EventBase
    {
        public enum ReasonEnum
        {
            [DataMember(Name = "Distance")] Distance,
            [DataMember(Name = "NoReason")] NoReason,
            [DataMember(Name = "NoSpace")] NoSpace,
            [DataMember(Name = "Offences")] Offences,

            [DataMember(Name = "RestrictedAccess")]
            RestrictedAccess
        }

        public enum StationTypeEnum
        {
            [DataMember(Name = "Coriolis")] Coriolis,
            [DataMember(Name = "CraterOutpost")] CraterOutpost,
            [DataMember(Name = "FleetCarrier")] FleetCarrier,
            [DataMember(Name = "Ocellus")] Ocellus,
            [DataMember(Name = "Orbis")] Orbis,
            [DataMember(Name = "Outpost")] Outpost
        }

        [DataMember(Name = "Reason")] public ReasonEnum Reason { get; set; }

        [DataMember(Name = "MarketID")] public long MarketId { get; set; }

        [DataMember(Name = "StationName")] public string StationName { get; set; }

        [DataMember(Name = "StationType")] public StationTypeEnum StationType { get; set; }
    }
}