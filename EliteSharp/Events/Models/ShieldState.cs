using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class ShieldState : EventBase
    {
        [DataMember(Name = "ShieldsUp")] public bool ShieldsUp { get; set; }
    }
}