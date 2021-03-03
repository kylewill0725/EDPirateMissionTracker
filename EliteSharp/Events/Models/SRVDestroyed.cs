using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class SrvDestroyed : EventBase
    {
        [DataMember(Name = "ID")] public long Id { get; set; }
    }
}