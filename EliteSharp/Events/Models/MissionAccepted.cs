using System;
using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class MissionAccepted : EventBase
    {
        [DataMember(Name = "Faction")] public string Faction { get; set; }

        [DataMember(Name = "Name")] public string Name { get; set; }

        [DataMember(Name = "LocalisedName")] public string LocalisedName { get; set; }

        [DataMember(Name = "TargetType", IsRequired = false)]
        public string? TargetType { get; set; }

        [DataMember(Name = "TargetType_Localised", IsRequired = false)]
        public string? TargetTypeLocalised { get; set; }

        [DataMember(Name = "TargetFaction", IsRequired = false)]
        public string? TargetFaction { get; set; }

        [DataMember(Name = "DestinationSystem", IsRequired = false)]
        public string? DestinationSystem { get; set; }

        [DataMember(Name = "DestinationStation", IsRequired = false)]
        public string? DestinationStation { get; set; }

        [DataMember(Name = "Target", IsRequired = false)]
        public string? Target { get; set; }

        [DataMember(Name = "Expiry", IsRequired = false)]
        public DateTimeOffset? Expiry { get; set; }

        [DataMember(Name = "Wing")] public bool Wing { get; set; }

        [DataMember(Name = "Influence")] public string Influence { get; set; }

        [DataMember(Name = "Reputation")] public string Reputation { get; set; }

        [DataMember(Name = "Reward", IsRequired = false)]
        public long? Reward { get; set; }

        [DataMember(Name = "MissionID")] public long MissionId { get; set; }

        [DataMember(Name = "Commodity", IsRequired = false)]
        public string? Commodity { get; set; }

        [DataMember(Name = "Commodity_Localised", IsRequired = false)]
        public string? CommodityLocalised { get; set; }

        [DataMember(Name = "Count", IsRequired = false)]
        public long? Count { get; set; }

        [DataMember(Name = "KillCount", IsRequired = false)]
        public long? KillCount { get; set; }

        [DataMember(Name = "Donation", IsRequired = false)]
        public string? Donation { get; set; }
    }
}