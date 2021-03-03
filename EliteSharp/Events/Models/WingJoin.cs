using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class WingJoin : EventBase
    {
        [DataMember(Name = "Others")] public string[] Others { get; set; }
    }
}