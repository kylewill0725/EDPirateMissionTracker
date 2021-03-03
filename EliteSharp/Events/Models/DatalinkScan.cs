using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class DatalinkScan : EventBase
    {
        [DataMember(Name = "Message")] public string Message { get; set; }

        [DataMember(Name = "Message_Localised")]
        public string MessageLocalised { get; set; }
    }
}