using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class RestockVehicle : EventBase
    {
        [DataMember(Name = "Type")] public string Type { get; set; }

        [DataMember(Name = "Loadout")] public string Loadout { get; set; }

        [DataMember(Name = "Cost")] public long Cost { get; set; }

        [DataMember(Name = "Count")] public long Count { get; set; }
    }
}