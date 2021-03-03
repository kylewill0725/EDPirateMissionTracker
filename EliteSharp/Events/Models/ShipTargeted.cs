using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class ShipTargeted : EventBase
    {
        [DataMember(Name = "TargetLocked")] public bool TargetLocked { get; set; }

        [DataMember(Name = "Ship", IsRequired = false)]
        public string? Ship { get; set; }

        [DataMember(Name = "Ship_Localised", IsRequired = false)]
        public string? ShipLocalised { get; set; }

        [DataMember(Name = "ScanStage", IsRequired = false)]
        public long? ScanStage { get; set; }

        [DataMember(Name = "PilotName", IsRequired = false)]
        public string? PilotName { get; set; }

        [DataMember(Name = "PilotName_Localised", IsRequired = false)]
        public string? PilotNameLocalised { get; set; }

        [DataMember(Name = "PilotRank", IsRequired = false)]
        public string? PilotRank { get; set; }

        [DataMember(Name = "ShieldHealth", IsRequired = false)]
        public double? ShieldHealth { get; set; }

        [DataMember(Name = "HullHealth", IsRequired = false)]
        public double? HullHealth { get; set; }

        [DataMember(Name = "Faction", IsRequired = false)]
        public string? Faction { get; set; }

        [DataMember(Name = "LegalStatus", IsRequired = false)]
        public string? LegalStatus { get; set; }

        [DataMember(Name = "Bounty", IsRequired = false)]
        public long? Bounty { get; set; }

        [DataMember(Name = "Subsystem", IsRequired = false)]
        public string? Subsystem { get; set; }

        [DataMember(Name = "Subsystem_Localised", IsRequired = false)]
        public string? SubsystemLocalised { get; set; }

        [DataMember(Name = "SubsystemHealth", IsRequired = false)]
        public double? SubsystemHealth { get; set; }

        [DataMember(Name = "SquadronID", IsRequired = false)]
        public string? SquadronId { get; set; }
    }
}