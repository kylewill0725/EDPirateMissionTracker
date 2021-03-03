using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class DockingGranted : EventBase
    {
        [DataMember(Name = "LandingPad")] public long LandingPad { get; set; }

        [DataMember(Name = "MarketID")] public long MarketId { get; set; }

        [DataMember(Name = "StationName")] public string StationName { get; set; }

        [DataMember(Name = "StationType")] public string StationType { get; set; }
    }
}