using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class DockingRequested : EventBase
    {
        [DataMember(Name = "MarketID")] public long MarketId { get; set; }

        [DataMember(Name = "StationName")] public string StationName { get; set; }

        [DataMember(Name = "StationType")] public string StationType { get; set; }
    }
}