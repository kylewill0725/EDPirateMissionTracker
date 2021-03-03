using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class FighterRebuilt : EventBase
    {
        public enum LoadoutEnum
        {
            [DataMember(Name = "one")] One,
            [DataMember(Name = "three")] Three,
            [DataMember(Name = "two")] Two
        }

        [DataMember(Name = "Loadout")] public LoadoutEnum Loadout { get; set; }

        [DataMember(Name = "ID")] public long Id { get; set; }
    }
}