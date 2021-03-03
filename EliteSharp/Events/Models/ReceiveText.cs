using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class ReceiveText : EventBase
    {
        public enum ChannelEnum
        {
            [DataMember(Name = "npc")] Npc,
            [DataMember(Name = "player")] Player,
            [DataMember(Name = "starsystem")] Starsystem,
            [DataMember(Name = "wing")] Wing
        }

        [DataMember(Name = "From")] public string From { get; set; }

        [DataMember(Name = "Message")] public string Message { get; set; }

        [DataMember(Name = "Message_Localised", IsRequired = false)]
        public string? MessageLocalised { get; set; }

        [DataMember(Name = "Channel")] public ChannelEnum Channel { get; set; }

        [DataMember(Name = "From_Localised", IsRequired = false)]
        public string? FromLocalised { get; set; }
    }
}