using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class CarrierNameChange : EventBase
    {
        [DataMember(Name = "CarrierID")] public long CarrierId { get; set; }

        [DataMember(Name = "Name")] public string Name { get; set; }

        [DataMember(Name = "Callsign")] public string Callsign { get; set; }
    }
}