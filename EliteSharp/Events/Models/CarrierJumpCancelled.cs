using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class CarrierJumpCancelled : EventBase
    {
        [DataMember(Name = "CarrierID")] public long CarrierId { get; set; }
    }
}