using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class FighterRebuilt : EventBase
    {
        [DataMember(Name = "Loadout")] public string Loadout { get; set; }

        [DataMember(Name = "ID")] public long Id { get; set; }
    }
}