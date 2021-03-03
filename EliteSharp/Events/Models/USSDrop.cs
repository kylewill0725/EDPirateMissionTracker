using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class UssDrop : EventBase
    {
        public enum UssTypeEnum
        {
            [DataMember(Name = "$USS_Type_Convoy;")]
            UssTypeConvoy,

            [DataMember(Name = "$USS_Type_DistressSignal;")]
            UssTypeDistressSignal,

            [DataMember(Name = "$USS_Type_Salvage;")]
            UssTypeSalvage,

            [DataMember(Name = "$USS_Type_ValuableSalvage;")]
            UssTypeValuableSalvage,

            [DataMember(Name = "$USS_Type_VeryValuableSalvage;")]
            UssTypeVeryValuableSalvage,

            [DataMember(Name = "$USS_Type_WeaponsFire;")]
            UssTypeWeaponsFire
        }

        public enum UssTypeLocalisedEnum
        {
            [DataMember(Name = "Convoy dispersal pattern")]
            ConvoyDispersalPattern,

            [DataMember(Name = "Degraded emissions")]
            DegradedEmissions,
            [DataMember(Name = "Distress call")] DistressCall,

            [DataMember(Name = "Encoded emissions")]
            EncodedEmissions,

            [DataMember(Name = "High grade emissions")]
            HighGradeEmissions,
            [DataMember(Name = "Weapons fire")] WeaponsFire
        }

        [DataMember(Name = "USSType")] public UssTypeEnum UssType { get; set; }

        [DataMember(Name = "USSType_Localised")]
        public UssTypeLocalisedEnum UssTypeLocalised { get; set; }

        [DataMember(Name = "USSThreat")] public long UssThreat { get; set; }
    }
}