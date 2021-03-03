using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class StartJump : EventBase
    {
        public enum JumpTypeEnum
        {
            [DataMember(Name = "Hyperspace")] Hyperspace,
            [DataMember(Name = "Supercruise")] Supercruise
        }

        public enum StarClassEnum
        {
            [DataMember(Name = "A")] A,
            [DataMember(Name = "B")] B,
            [DataMember(Name = "DA")] Da,
            [DataMember(Name = "DAZ")] Daz,
            [DataMember(Name = "DC")] Dc,
            [DataMember(Name = "F")] F,
            [DataMember(Name = "G")] G,
            [DataMember(Name = "K")] K,
            [DataMember(Name = "L")] L,
            [DataMember(Name = "M")] M,
            [DataMember(Name = "T")] T,
            [DataMember(Name = "TTS")] Tts,
            [DataMember(Name = "Y")] Y
        }

        [DataMember(Name = "JumpType")] public JumpTypeEnum JumpType { get; set; }

        [DataMember(Name = "StarSystem", IsRequired = false)]
        public string? StarSystem { get; set; }

        [DataMember(Name = "SystemAddress", IsRequired = false)]
        public long? SystemAddress { get; set; }

        [DataMember(Name = "StarClass", IsRequired = false)]
        public StarClassEnum? StarClass { get; set; }
    }
}