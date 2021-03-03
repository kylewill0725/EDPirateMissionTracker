using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class FsdTarget : EventBase
    {
        public enum StarClassEnum
        {
            [DataMember(Name = "A")] A,
            [DataMember(Name = "B")] B,
            [DataMember(Name = "D")] D,
            [DataMember(Name = "DA")] Da,
            [DataMember(Name = "DAZ")] Daz,
            [DataMember(Name = "DC")] Dc,
            [DataMember(Name = "F")] F,
            [DataMember(Name = "G")] G,
            [DataMember(Name = "K")] K,
            [DataMember(Name = "L")] L,
            [DataMember(Name = "M")] M,
            [DataMember(Name = "N")] N,
            [DataMember(Name = "T")] T,
            [DataMember(Name = "TTS")] Tts,
            [DataMember(Name = "Y")] Y
        }

        [DataMember(Name = "Name")] public string Name { get; set; }

        [DataMember(Name = "SystemAddress")] public long SystemAddress { get; set; }

        [DataMember(Name = "StarClass")] public StarClassEnum StarClass { get; set; }

        [DataMember(Name = "RemainingJumpsInRoute", IsRequired = false)]
        public long? RemainingJumpsInRoute { get; set; }
    }
}