using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class MissionFailed : EventBase
    {
        [DataMember(Name = "Name")] public string Name { get; set; }

        [DataMember(Name = "MissionID")] public long MissionId { get; set; }
    }
}