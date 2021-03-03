using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class CrewAssign : EventBase
    {
        [DataMember(Name = "Name")] public string Name { get; set; }

        [DataMember(Name = "CrewID")] public long CrewId { get; set; }

        [DataMember(Name = "Role")] public string Role { get; set; }
    }
}