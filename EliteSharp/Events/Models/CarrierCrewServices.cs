using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class CarrierCrewServices : EventBase
    {
        public enum OperationEnum
        {
            [DataMember(Name = "Activate")] Activate,
            [DataMember(Name = "Pause")] Pause,
            [DataMember(Name = "Replace")] Replace,
            [DataMember(Name = "Resume")] Resume
        }

        [DataMember(Name = "CarrierID")] public long CarrierId { get; set; }

        [DataMember(Name = "CrewRole")] public string CrewRole { get; set; }

        [DataMember(Name = "Operation")] public OperationEnum Operation { get; set; }

        [DataMember(Name = "CrewName")] public string CrewName { get; set; }
    }
}