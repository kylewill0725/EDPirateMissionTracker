using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class LoadGame : EventBase
    {
        public enum GameModeEnum
        {
            [DataMember(Name = "Group")] Group,
            [DataMember(Name = "Open")] Open,
            [DataMember(Name = "Solo")] Solo
        }

        public enum ShipEnum
        {
            [DataMember(Name = "Anaconda")] Anaconda,
            [DataMember(Name = "Asp")] Asp,
            [DataMember(Name = "Eagle")] Eagle,
            [DataMember(Name = "Hauler")] Hauler,
            [DataMember(Name = "Python")] Python,
            [DataMember(Name = "TestBuggy")] TestBuggy,
            [DataMember(Name = "Type7")] Type7,
            [DataMember(Name = "Type9")] Type9,
            [DataMember(Name = "Vulture")] Vulture
        }

        public enum ShipLocalisedEnum
        {
            [DataMember(Name = "Asp Explorer")] AspExplorer,
            [DataMember(Name = "SRV Scarab")] SrvScarab,

            [DataMember(Name = "Type-7 Transporter")]
            Type7Transporter,
            [DataMember(Name = "Type-9 Heavy")] Type9Heavy
        }

        [DataMember(Name = "FID")] public string Fid { get; set; }

        [DataMember(Name = "Commander")] public string Commander { get; set; }

        [DataMember(Name = "Horizons")] public bool Horizons { get; set; }

        [DataMember(Name = "Ship")] public ShipEnum Ship { get; set; }

        [DataMember(Name = "ShipID")] public long ShipId { get; set; }

        [DataMember(Name = "ShipName")] public string ShipName { get; set; }

        [DataMember(Name = "ShipIdent")] public string ShipIdent { get; set; }

        [DataMember(Name = "FuelLevel")] public double FuelLevel { get; set; }

        [DataMember(Name = "FuelCapacity")] public double FuelCapacity { get; set; }

        [DataMember(Name = "GameMode")] public GameModeEnum GameMode { get; set; }

        [DataMember(Name = "Group", IsRequired = false)]
        public string? Group { get; set; }

        [DataMember(Name = "Credits")] public long Credits { get; set; }

        [DataMember(Name = "Loan")] public long Loan { get; set; }

        [DataMember(Name = "Ship_Localised", IsRequired = false)]
        public ShipLocalisedEnum? ShipLocalised { get; set; }

        [DataMember(Name = "StartLanded", IsRequired = false)]
        public bool? StartLanded { get; set; }
    }
}