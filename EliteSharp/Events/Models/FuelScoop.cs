using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class FuelScoop : EventBase
    {
        [DataMember(Name = "Scooped")] public double Scooped { get; set; }

        [DataMember(Name = "Total")] public double Total { get; set; }
    }
}