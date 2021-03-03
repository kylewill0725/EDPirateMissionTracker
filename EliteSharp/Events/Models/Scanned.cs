using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class Scanned : EventBase
    {
        public enum ScanTypeEnum
        {
            [DataMember(Name = "Cargo")] Cargo,
            [DataMember(Name = "Crime")] Crime
        }

        [DataMember(Name = "ScanType")] public ScanTypeEnum ScanType { get; set; }
    }
}