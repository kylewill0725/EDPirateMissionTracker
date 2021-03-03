using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class CarrierBankTransfer : EventBase
    {
        [DataMember(Name = "CarrierID")] public long CarrierId { get; set; }

        [DataMember(Name = "Deposit")] public long Deposit { get; set; }

        [DataMember(Name = "PlayerBalance")] public long PlayerBalance { get; set; }

        [DataMember(Name = "CarrierBalance")] public long CarrierBalance { get; set; }
    }
}