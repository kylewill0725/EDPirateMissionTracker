using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class DockingDenied : EventBase
    {
        [DataMember(Name = "Reason")] public string Reason { get; set; }

        [DataMember(Name = "MarketID")] public long MarketId { get; set; }

        [DataMember(Name = "StationName")] public string StationName { get; set; }

        [DataMember(Name = "StationType")] public string StationType { get; set; }
    }
}