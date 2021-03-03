using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class KickedFromSquadron : EventBase
    {
        [DataMember(Name = "SquadronName")] public string SquadronName { get; set; }
    }
}