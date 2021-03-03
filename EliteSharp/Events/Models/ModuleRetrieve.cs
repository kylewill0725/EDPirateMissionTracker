using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class ModuleRetrieve : EventBase
    {
        [DataMember(Name = "MarketID")] public long MarketId { get; set; }

        [DataMember(Name = "Slot")] public string Slot { get; set; }

        [DataMember(Name = "RetrievedItem")] public string RetrievedItem { get; set; }

        [DataMember(Name = "RetrievedItem_Localised")]
        public string RetrievedItemLocalised { get; set; }

        [DataMember(Name = "Ship")] public string Ship { get; set; }

        [DataMember(Name = "ShipID")] public long ShipId { get; set; }

        [DataMember(Name = "Hot")] public bool Hot { get; set; }

        [DataMember(Name = "SwapOutItem")] public string SwapOutItem { get; set; }

        [DataMember(Name = "SwapOutItem_Localised")]
        public string SwapOutItemLocalised { get; set; }

        [DataMember(Name = "EngineerModifications", IsRequired = false)]
        public string? EngineerModifications { get; set; }

        [DataMember(Name = "Level", IsRequired = false)]
        public long? Level { get; set; }

        [DataMember(Name = "Quality", IsRequired = false)]
        public double? Quality { get; set; }
    }
}