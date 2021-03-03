using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class RedeemVoucher : EventBase
    {
        [DataMember(Name = "Type", IsRequired = false)]
        public string? Type { get; set; }

        [DataMember(Name = "Amount")] public long Amount { get; set; }

        [DataMember(Name = "Factions", IsRequired = false)]
        public string[]? Factions { get; set; }

        [DataMember(Name = "BrokerPercentage", IsRequired = false)]
        public double? BrokerPercentage { get; set; }

        [DataMember(Name = "Faction", IsRequired = false)]
        public string? Faction { get; set; }
    }
}