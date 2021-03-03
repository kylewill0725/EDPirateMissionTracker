using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class BuyAmmo : EventBase
    {
        [DataMember(Name = "Cost")] public long Cost { get; set; }
    }
}