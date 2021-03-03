using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class JetConeBoost : EventBase
    {
        [DataMember(Name = "BoostValue")] public double BoostValue { get; set; }
    }
}