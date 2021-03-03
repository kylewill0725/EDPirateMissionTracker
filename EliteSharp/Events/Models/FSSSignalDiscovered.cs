using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class FssSignalDiscovered : EventBase
    {
        [DataMember(Name = "SystemAddress")] public long SystemAddress { get; set; }

        [DataMember(Name = "SignalName")] public string SignalName { get; set; }

        [DataMember(Name = "IsStation", IsRequired = false)]
        public bool? IsStation { get; set; }

        [DataMember(Name = "SignalName_Localised", IsRequired = false)]
        public string? SignalNameLocalised { get; set; }
    }
}