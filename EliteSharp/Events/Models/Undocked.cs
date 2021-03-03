using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class Undocked : EventBase
    {
        [DataMember(Name = "StationName")] public string StationName { get; set; }

        [DataMember(Name = "StationType")] public string StationType { get; set; }

        [DataMember(Name = "MarketID")] public long MarketId { get; set; }
    }
}