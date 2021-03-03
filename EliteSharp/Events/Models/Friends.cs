using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class Friends : EventBase
    {
        [DataMember(Name = "Status")] public string Status { get; set; }

        [DataMember(Name = "Name")] public string Name { get; set; }
    }
}