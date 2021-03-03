using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class WingInvite : EventBase
    {
        [DataMember(Name = "Name")] public string Name { get; set; }
    }
}