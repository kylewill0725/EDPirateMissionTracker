using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class CarrierDepositFuel : EventBase
    {
        [DataMember(Name = "CarrierID")] public long CarrierId { get; set; }

        [DataMember(Name = "Amount")] public long Amount { get; set; }

        [DataMember(Name = "Total")] public long Total { get; set; }
    }
}