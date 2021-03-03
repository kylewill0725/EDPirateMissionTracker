using System.Runtime.Serialization;

namespace EliteSharp.GameModel
{
    public enum ShipTypeEnum
    {
        [DataMember(Name = "anaconda")] Anaconda,
        [DataMember(Name = "asp")] Asp,
        [DataMember(Name = "eagle")] Eagle,
        [DataMember(Name = "hauler")] Hauler,
        [DataMember(Name = "python")] Python,
        [DataMember(Name = "sidewinder")] Sidewinder,
        [DataMember(Name = "type7")] Type7,
        [DataMember(Name = "type9")] Type9,
        [DataMember(Name = "vulture")] Vulture
    }
}