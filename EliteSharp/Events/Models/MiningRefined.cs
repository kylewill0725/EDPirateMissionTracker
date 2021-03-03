using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class MiningRefined : EventBase
    {
        [DataMember(Name = "Type")] public string Type { get; set; }

        [DataMember(Name = "Type_Localised")] public string TypeLocalised { get; set; }
    }
}