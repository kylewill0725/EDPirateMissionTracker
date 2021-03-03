using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class LaunchSrv : EventBase
    {
        public enum LoadoutEnum
        {
            [DataMember(Name = "starter")] Starter
        }

        [DataMember(Name = "Loadout")] public LoadoutEnum Loadout { get; set; }

        [DataMember(Name = "ID")] public long Id { get; set; }

        [DataMember(Name = "PlayerControlled")]
        public bool PlayerControlled { get; set; }
    }
}