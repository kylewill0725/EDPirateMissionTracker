using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class Outfitting : EventBase
    {
        [DataMember(Name = "MarketID")] public long MarketId { get; set; }

        [DataMember(Name = "StationName")] public string StationName { get; set; }

        [DataMember(Name = "StarSystem")] public string StarSystem { get; set; }
    }
}