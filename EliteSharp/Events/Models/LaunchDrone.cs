using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class LaunchDrone : EventBase
    {
        [DataMember(Name = "Type")] public string Type { get; set; }
    }
}