using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class LoadGame : EventBase
    {
        [DataMember(Name = "FID")] public string Fid { get; set; }

        [DataMember(Name = "Commander")] public string Commander { get; set; }

        [DataMember(Name = "Horizons")] public bool Horizons { get; set; }

        [DataMember(Name = "Ship")] public string Ship { get; set; }

        [DataMember(Name = "ShipID")] public long ShipId { get; set; }

        [DataMember(Name = "ShipName")] public string ShipName { get; set; }

        [DataMember(Name = "ShipIdent")] public string ShipIdent { get; set; }

        [DataMember(Name = "FuelLevel")] public double FuelLevel { get; set; }

        [DataMember(Name = "FuelCapacity")] public double FuelCapacity { get; set; }

        [DataMember(Name = "GameMode")] public string GameMode { get; set; }

        [DataMember(Name = "Group", IsRequired = false)]
        public string? Group { get; set; }

        [DataMember(Name = "Credits")] public long Credits { get; set; }

        [DataMember(Name = "Loan")] public long Loan { get; set; }

        [DataMember(Name = "Ship_Localised", IsRequired = false)]
        public string? ShipLocalised { get; set; }

        [DataMember(Name = "StartLanded", IsRequired = false)]
        public bool? StartLanded { get; set; }
    }
}