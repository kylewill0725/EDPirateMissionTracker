using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class UssDrop : EventBase
    {
        [DataMember(Name = "USSType")] public string UssType { get; set; }

        [DataMember(Name = "USSType_Localised")]
        public string UssTypeLocalised { get; set; }

        [DataMember(Name = "USSThreat")] public long UssThreat { get; set; }
    }
}