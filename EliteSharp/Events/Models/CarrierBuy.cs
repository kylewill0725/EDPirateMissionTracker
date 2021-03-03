using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class CarrierBuy : EventBase
    {
        [DataMember(Name = "CarrierID")] public long CarrierId { get; set; }

        [DataMember(Name = "BoughtAtMarket")] public long BoughtAtMarket { get; set; }

        [DataMember(Name = "Location")] public string Location { get; set; }

        [DataMember(Name = "SystemAddress")] public long SystemAddress { get; set; }

        [DataMember(Name = "Price")] public long Price { get; set; }

        [DataMember(Name = "Variant")] public string Variant { get; set; }

        [DataMember(Name = "Callsign")] public string Callsign { get; set; }
    }
}