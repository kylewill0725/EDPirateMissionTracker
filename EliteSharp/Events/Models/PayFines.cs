using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class PayFines : EventBase
    {
        [DataMember(Name = "Amount")] public long Amount { get; set; }

        [DataMember(Name = "AllFines")] public bool AllFines { get; set; }

        [DataMember(Name = "ShipID")] public long ShipId { get; set; }

        [DataMember(Name = "Faction", IsRequired = false)]
        public string? Faction { get; set; }
    }
}