using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class SendText : EventBase
    {
        [DataMember(Name = "To")] public string To { get; set; }

        [DataMember(Name = "Message")] public string Message { get; set; }

        [DataMember(Name = "Sent")] public bool Sent { get; set; }
    }
}