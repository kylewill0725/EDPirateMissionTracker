using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class ModuleSwap : EventBase
    {
        [DataMember(Name = "MarketID")] public long MarketId { get; set; }

        [DataMember(Name = "FromSlot")] public string FromSlot { get; set; }

        [DataMember(Name = "ToSlot")] public string ToSlot { get; set; }

        [DataMember(Name = "FromItem")] public string FromItem { get; set; }

        [DataMember(Name = "FromItem_Localised")]
        public string FromItemLocalised { get; set; }

        [DataMember(Name = "ToItem")] public string ToItem { get; set; }

        [DataMember(Name = "ToItem_Localised")]
        public string ToItemLocalised { get; set; }

        [DataMember(Name = "Ship")] public string Ship { get; set; }

        [DataMember(Name = "ShipID")] public long ShipId { get; set; }
    }
}