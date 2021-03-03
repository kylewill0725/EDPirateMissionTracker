using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class RefuelAll : EventBase
    {
        [DataMember(Name = "Cost")] public long Cost { get; set; }

        [DataMember(Name = "Amount")] public double Amount { get; set; }
    }
}