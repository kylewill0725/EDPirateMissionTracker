using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class CarrierCrewServices : EventBase
    {
        [DataMember(Name = "CarrierID")] public long CarrierId { get; set; }

        [DataMember(Name = "CrewRole")] public string CrewRole { get; set; }

        [DataMember(Name = "Operation")] public string Operation { get; set; }

        [DataMember(Name = "CrewName")] public string CrewName { get; set; }
    }
}