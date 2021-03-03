using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class Market : EventBase
    {
        [DataMember(Name = "MarketID")] public long MarketId { get; set; }

        [DataMember(Name = "StationName")] public string StationName { get; set; }

        [DataMember(Name = "StationType")] public string StationType { get; set; }

        [DataMember(Name = "StarSystem")] public string StarSystem { get; set; }

        [DataMember(Name = "CarrierDockingAccess", IsRequired = false)]
        public string? CarrierDockingAccess { get; set; }
    }
}