using System.Runtime.Serialization;

namespace EliteSharp.GameModel
{
    public enum ShipTypeLocalisedEnum
    {
        [DataMember(Name = "Asp Explorer")] AspExplorer,

        [DataMember(Name = "Type-7 Transporter")]
        Type7Transporter,
        [DataMember(Name = "Type-9 Heavy")] Type9Heavy
    }
}