using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class RepairAll : EventBase
    {
        [DataMember(Name = "Cost")] public long Cost { get; set; }
    }
}