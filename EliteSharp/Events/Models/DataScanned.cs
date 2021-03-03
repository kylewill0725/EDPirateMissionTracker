using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class DataScanned : EventBase
    {
        [DataMember(Name = "Type")] public string Type { get; set; }
    }
}