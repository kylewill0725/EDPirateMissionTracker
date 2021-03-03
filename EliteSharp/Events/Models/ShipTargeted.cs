using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class ShipTargeted : EventBase
    {
        public enum LegalStatusEnum
        {
            [DataMember(Name = "Clean")] Clean,
            [DataMember(Name = "Lawless")] Lawless,
            [DataMember(Name = "Wanted")] Wanted
        }

        public enum PilotRankEnum
        {
            [DataMember(Name = "Competent")] Competent,
            [DataMember(Name = "Dangerous")] Dangerous,
            [DataMember(Name = "Deadly")] Deadly,
            [DataMember(Name = "Elite")] Elite,
            [DataMember(Name = "Expert")] Expert,
            [DataMember(Name = "Harmless")] Harmless,
            [DataMember(Name = "Master")] Master,
            [DataMember(Name = "Mostly Harmless")] MostlyHarmless,
            [DataMember(Name = "Novice")] Novice
        }

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
        public PilotRankEnum? PilotRank { get; set; }

        [DataMember(Name = "ShieldHealth", IsRequired = false)]
        public double? ShieldHealth { get; set; }

        [DataMember(Name = "HullHealth", IsRequired = false)]
        public double? HullHealth { get; set; }

        [DataMember(Name = "Faction", IsRequired = false)]
        public string? Faction { get; set; }

        [DataMember(Name = "LegalStatus", IsRequired = false)]
        public LegalStatusEnum? LegalStatus { get; set; }

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