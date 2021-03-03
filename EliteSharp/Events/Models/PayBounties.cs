using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class PayBounties : EventBase
    {
        [DataMember(Name = "Amount")] public long Amount { get; set; }

        [DataMember(Name = "Faction")] public string Faction { get; set; }

        [DataMember(Name = "Faction_Localised")]
        public string FactionLocalised { get; set; }

        [DataMember(Name = "ShipID")] public long ShipId { get; set; }

        [DataMember(Name = "BrokerPercentage")]
        public double BrokerPercentage { get; set; }
    }
}