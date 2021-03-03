using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class EscapeInterdiction : EventBase
    {
        [DataMember(Name = "Interdictor")] public string Interdictor { get; set; }

        [DataMember(Name = "IsPlayer")] public bool IsPlayer { get; set; }

        [DataMember(Name = "Interdictor_Localised", IsRequired = false)]
        public string? InterdictorLocalised { get; set; }
    }
}