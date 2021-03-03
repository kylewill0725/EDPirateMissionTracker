using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class CarrierModulePack : EventBase
    {
        [DataMember(Name = "CarrierID")] public long CarrierId { get; set; }

        [DataMember(Name = "Operation")] public string Operation { get; set; }

        [DataMember(Name = "PackTheme")] public string PackTheme { get; set; }

        [DataMember(Name = "PackTier")] public long PackTier { get; set; }

        [DataMember(Name = "Cost")] public long Cost { get; set; }
    }
}