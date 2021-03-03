using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class NavBeaconScan : EventBase
    {
        [DataMember(Name = "SystemAddress")] public long SystemAddress { get; set; }

        [DataMember(Name = "NumBodies")] public long NumBodies { get; set; }
    }
}