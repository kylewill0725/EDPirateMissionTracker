using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class LaunchFighter : EventBase
    {
        [DataMember(Name = "Loadout")] public string Loadout { get; set; }

        [DataMember(Name = "ID")] public long Id { get; set; }

        [DataMember(Name = "PlayerControlled")]
        public bool PlayerControlled { get; set; }
    }
}