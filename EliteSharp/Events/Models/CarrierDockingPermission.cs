using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class CarrierDockingPermission : EventBase
    {
        [DataMember(Name = "CarrierID")] public long CarrierId { get; set; }

        [DataMember(Name = "DockingAccess")] public string DockingAccess { get; set; }

        [DataMember(Name = "AllowNotorious")] public bool AllowNotorious { get; set; }
    }
}