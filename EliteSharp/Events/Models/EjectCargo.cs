using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class EjectCargo : EventBase
    {
        [DataMember(Name = "Type")] public string Type { get; set; }

        [DataMember(Name = "Count")] public long Count { get; set; }

        [DataMember(Name = "Abandoned")] public bool Abandoned { get; set; }

        [DataMember(Name = "Type_Localised", IsRequired = false)]
        public string? TypeLocalised { get; set; }
    }
}