using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class ReservoirReplenished : EventBase
    {
        [DataMember(Name = "FuelMain")] public double FuelMain { get; set; }

        [DataMember(Name = "FuelReservoir")] public double FuelReservoir { get; set; }
    }
}