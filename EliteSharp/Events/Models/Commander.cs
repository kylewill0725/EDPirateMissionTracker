using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class Commander : EventBase
    {
        [DataMember(Name = "FID")] public string Fid { get; set; }

        [DataMember(Name = "Name")] public string Name { get; set; }
    }
}