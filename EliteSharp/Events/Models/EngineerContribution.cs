using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class EngineerContribution : EventBase
    {
        [DataMember(Name = "Engineer")] public string Engineer { get; set; }

        [DataMember(Name = "EngineerID")] public long EngineerId { get; set; }

        [DataMember(Name = "Type")] public string Type { get; set; }

        [DataMember(Name = "Commodity", IsRequired = false)]
        public string? Commodity { get; set; }

        [DataMember(Name = "Commodity_Localised", IsRequired = false)]
        public string? CommodityLocalised { get; set; }

        [DataMember(Name = "Quantity")] public long Quantity { get; set; }

        [DataMember(Name = "TotalQuantity")] public long TotalQuantity { get; set; }

        [DataMember(Name = "Material", IsRequired = false)]
        public string? Material { get; set; }

        [DataMember(Name = "Material_Localised", IsRequired = false)]
        public string? MaterialLocalised { get; set; }
    }
}