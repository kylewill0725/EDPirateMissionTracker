using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class MaterialDiscovered : EventBase
    {
        [DataMember(Name = "Category")] public string Category { get; set; }

        [DataMember(Name = "Name")] public string Name { get; set; }

        [DataMember(Name = "Name_Localised", IsRequired = false)]
        public string? NameLocalised { get; set; }

        [DataMember(Name = "DiscoveryNumber")] public long DiscoveryNumber { get; set; }
    }
}