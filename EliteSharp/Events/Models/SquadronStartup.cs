using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class SquadronStartup : EventBase
    {
        [DataMember(Name = "SquadronName")] public string SquadronName { get; set; }

        [DataMember(Name = "CurrentRank")] public long CurrentRank { get; set; }
    }
}