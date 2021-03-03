using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class VehicleSwitch : EventBase
    {
        [DataMember(Name = "To")] public string To { get; set; }
    }
}