using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class Repair : EventBase
    {
        [DataMember(Name = "Items")] public string[] Items { get; set; }

        [DataMember(Name = "Cost")] public long Cost { get; set; }
    }
}