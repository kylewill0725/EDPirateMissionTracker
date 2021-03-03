using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class BuyExplorationData : EventBase
    {
        [DataMember(Name = "System")] public string System { get; set; }

        [DataMember(Name = "Cost")] public long Cost { get; set; }
    }
}