using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class FssSignalDiscovered : EventBase
    {
        public enum SignalNameLocalisedEnum
        {
            [DataMember(Name = "Conflict Zone [High Intensity]")]
            ConflictZoneHighIntensity,

            [DataMember(Name = "Conflict Zone [Low Intensity]")]
            ConflictZoneLowIntensity,

            [DataMember(Name = "Conflict Zone [Medium Intensity]")]
            ConflictZoneMediumIntensity,
            [DataMember(Name = "Nav Beacon")] NavBeacon,

            [DataMember(Name = "Resource Extraction Site")]
            ResourceExtractionSite,

            [DataMember(Name = "Resource Extraction Site [Hazardous]")]
            ResourceExtractionSiteHazardous,

            [DataMember(Name = "Resource Extraction Site [High]")]
            ResourceExtractionSiteHigh,

            [DataMember(Name = "Resource Extraction Site [Low]")]
            ResourceExtractionSiteLow
        }

        [DataMember(Name = "SystemAddress")] public long SystemAddress { get; set; }

        [DataMember(Name = "SignalName")] public string SignalName { get; set; }

        [DataMember(Name = "IsStation", IsRequired = false)]
        public bool? IsStation { get; set; }

        [DataMember(Name = "SignalName_Localised", IsRequired = false)]
        public SignalNameLocalisedEnum? SignalNameLocalised { get; set; }
    }
}