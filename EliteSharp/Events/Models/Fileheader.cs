using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class Fileheader : EventBase
    {
        [DataMember(Name = "part")] public long Part { get; set; }

        [DataMember(Name = "language")] public string Language { get; set; }

        [DataMember(Name = "gameversion")] public string Gameversion { get; set; }

        [DataMember(Name = "build")] public string Build { get; set; }
    }
}