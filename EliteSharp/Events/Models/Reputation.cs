using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class Reputation : EventBase
    {
        [DataMember(Name = "Empire")] public double Empire { get; set; }

        [DataMember(Name = "Federation")] public double Federation { get; set; }

        [DataMember(Name = "Alliance")] public double Alliance { get; set; }
    }
}