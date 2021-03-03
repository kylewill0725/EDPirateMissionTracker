using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class ReceiveText : EventBase
    {
        [DataMember(Name = "From")] public string From { get; set; }

        [DataMember(Name = "Message")] public string Message { get; set; }

        [DataMember(Name = "Message_Localised", IsRequired = false)]
        public string? MessageLocalised { get; set; }

        [DataMember(Name = "Channel")] public string Channel { get; set; }

        [DataMember(Name = "From_Localised", IsRequired = false)]
        public string? FromLocalised { get; set; }
    }
}