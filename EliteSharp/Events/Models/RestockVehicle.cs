using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class RestockVehicle : EventBase
    {
        public enum LoadoutEnum
        {
            [DataMember(Name = "one")] One,
            [DataMember(Name = "starter")] Starter,
            [DataMember(Name = "three")] Three,
            [DataMember(Name = "two")] Two
        }

        public enum TypeEnum
        {
            [DataMember(Name = "empire_fighter")] EmpireFighter,

            [DataMember(Name = "federation_fighter")]
            FederationFighter,

            [DataMember(Name = "independent_fighter")]
            IndependentFighter,
            [DataMember(Name = "testbuggy")] Testbuggy
        }

        [DataMember(Name = "Type")] public TypeEnum Type { get; set; }

        [DataMember(Name = "Loadout")] public LoadoutEnum Loadout { get; set; }

        [DataMember(Name = "Cost")] public long Cost { get; set; }

        [DataMember(Name = "Count")] public long Count { get; set; }
    }
}