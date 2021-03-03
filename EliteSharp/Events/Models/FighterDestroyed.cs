using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class FighterDestroyed : EventBase
    {
        [DataMember(Name = "ID")] public long Id { get; set; }
    }
}