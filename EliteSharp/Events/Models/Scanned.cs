using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class Scanned : EventBase
    {
        [DataMember(Name = "ScanType")] public string ScanType { get; set; }
    }
}