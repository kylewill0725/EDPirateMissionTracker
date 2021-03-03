using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class CollectCargo : EventBase
    {
        [DataMember(Name = "Type")] public string Type { get; set; }

        [DataMember(Name = "Type_Localised", IsRequired = false)]
        public string? TypeLocalised { get; set; }

        [DataMember(Name = "Stolen")] public bool Stolen { get; set; }

        [DataMember(Name = "MissionID", IsRequired = false)]
        public long? MissionId { get; set; }
    }
}