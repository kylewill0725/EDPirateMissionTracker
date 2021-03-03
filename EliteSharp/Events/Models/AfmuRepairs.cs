using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class AfmuRepairs : EventBase
    {
        [DataMember(Name = "Module")] public string Module { get; set; }

        [DataMember(Name = "Module_Localised")]
        public string ModuleLocalised { get; set; }

        [DataMember(Name = "FullyRepaired")] public bool FullyRepaired { get; set; }

        [DataMember(Name = "Health")] public double Health { get; set; }
    }
}