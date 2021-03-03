using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class CarrierFinance : EventBase
    {
        [DataMember(Name = "CarrierID")] public long CarrierId { get; set; }

        [DataMember(Name = "TaxRate")] public long TaxRate { get; set; }

        [DataMember(Name = "CarrierBalance")] public long CarrierBalance { get; set; }

        [DataMember(Name = "ReserveBalance")] public long ReserveBalance { get; set; }

        [DataMember(Name = "AvailableBalance")]
        public long AvailableBalance { get; set; }

        [DataMember(Name = "ReservePercent")] public long ReservePercent { get; set; }
    }
}