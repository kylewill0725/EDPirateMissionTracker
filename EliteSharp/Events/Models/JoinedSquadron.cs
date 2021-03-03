using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class JoinedSquadron : EventBase
    {
        [DataMember(Name = "SquadronName")] public string SquadronName { get; set; }
    }
}