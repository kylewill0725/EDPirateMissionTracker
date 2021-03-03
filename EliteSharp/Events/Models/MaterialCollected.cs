using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class MaterialCollected : EventBase
    {
        public enum CategoryEnum
        {
            [DataMember(Name = "Encoded")] Encoded,
            [DataMember(Name = "Manufactured")] Manufactured,
            [DataMember(Name = "Raw")] Raw
        }

        [DataMember(Name = "Category")] public CategoryEnum Category { get; set; }

        [DataMember(Name = "Name")] public string Name { get; set; }

        [DataMember(Name = "Name_Localised", IsRequired = false)]
        public string? NameLocalised { get; set; }

        [DataMember(Name = "Count")] public long Count { get; set; }
    }
}