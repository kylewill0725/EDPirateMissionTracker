using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class WingAdd : EventBase
    {
        [DataMember(Name = "Name")] public string Name { get; set; }
    }
}