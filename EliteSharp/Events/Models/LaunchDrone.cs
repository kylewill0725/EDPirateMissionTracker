using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class LaunchDrone : EventBase
    {
        public enum TypeEnum
        {
            [DataMember(Name = "Collection")] Collection,
            [DataMember(Name = "FuelTransfer")] FuelTransfer,
            [DataMember(Name = "Prospector")] Prospector
        }

        [DataMember(Name = "Type")] public TypeEnum Type { get; set; }
    }
}