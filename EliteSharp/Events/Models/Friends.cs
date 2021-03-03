using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class Friends : EventBase
    {
        public enum StatusEnum
        {
            [DataMember(Name = "Added")] Added,
            [DataMember(Name = "Lost")] Lost,
            [DataMember(Name = "Offline")] Offline,
            [DataMember(Name = "Online")] Online,
            [DataMember(Name = "Requested")] Requested
        }

        [DataMember(Name = "Status")] public StatusEnum Status { get; set; }

        [DataMember(Name = "Name")] public string Name { get; set; }
    }
}