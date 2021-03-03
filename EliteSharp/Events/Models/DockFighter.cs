using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class DockFighter : EventBase
    {
        [DataMember(Name = "ID")] public long Id { get; set; }
    }
}