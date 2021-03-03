using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class Music : EventBase
    {
        [DataMember(Name = "MusicTrack")] public string MusicTrack { get; set; }
    }
}