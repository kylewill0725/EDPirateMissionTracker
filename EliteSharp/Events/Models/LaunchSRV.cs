using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class LaunchSrv : EventBase
    {
        [DataMember(Name = "Loadout")] public string Loadout { get; set; }

        [DataMember(Name = "ID")] public long Id { get; set; }

        [DataMember(Name = "PlayerControlled")]
        public bool PlayerControlled { get; set; }
    }
}