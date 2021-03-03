using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class RebootRepair : EventBase
    {
        [DataMember(Name = "Modules")] public string[] Modules { get; set; }
    }
}