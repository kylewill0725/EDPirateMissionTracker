using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class VehicleSwitch : EventBase
    {
        public enum VehicleEnum
        {
            [DataMember(Name = "Fighter")] Fighter,
            [DataMember(Name = "Mothership")] Mothership
        }

        [DataMember(Name = "To")] public VehicleEnum To { get; set; }
    }
}