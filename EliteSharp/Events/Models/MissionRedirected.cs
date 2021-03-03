using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class MissionRedirected : EventBase
    {
        [DataMember(Name = "MissionID")] public long MissionId { get; set; }

        [DataMember(Name = "Name")] public string Name { get; set; }

        [DataMember(Name = "NewDestinationStation")]
        public string NewDestinationStation { get; set; }

        [DataMember(Name = "NewDestinationSystem")]
        public string NewDestinationSystem { get; set; }

        [DataMember(Name = "OldDestinationStation")]
        public string OldDestinationStation { get; set; }

        [DataMember(Name = "OldDestinationSystem")]
        public string OldDestinationSystem { get; set; }
    }
}