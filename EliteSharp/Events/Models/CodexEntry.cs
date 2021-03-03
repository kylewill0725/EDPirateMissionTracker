using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class CodexEntry : EventBase
    {
        [DataMember(Name = "EntryID")] public long EntryId { get; set; }

        [DataMember(Name = "Name")] public string Name { get; set; }

        [DataMember(Name = "Name_Localised")] public string NameLocalised { get; set; }

        [DataMember(Name = "SubCategory")] public string SubCategory { get; set; }

        [DataMember(Name = "SubCategory_Localised")]
        public string SubCategoryLocalised { get; set; }

        [DataMember(Name = "Category")] public string Category { get; set; }

        [DataMember(Name = "Category_Localised")]
        public string CategoryLocalised { get; set; }

        [DataMember(Name = "Region")] public string Region { get; set; }

        [DataMember(Name = "Region_Localised")]
        public string RegionLocalised { get; set; }

        [DataMember(Name = "System")] public string System { get; set; }

        [DataMember(Name = "SystemAddress")] public long SystemAddress { get; set; }

        [DataMember(Name = "IsNewEntry", IsRequired = false)]
        public bool? IsNewEntry { get; set; }

        [DataMember(Name = "NearestDestination", IsRequired = false)]
        public string? NearestDestination { get; set; }

        [DataMember(Name = "NearestDestination_Localised", IsRequired = false)]
        public string? NearestDestinationLocalised { get; set; }

        [DataMember(Name = "VoucherAmount", IsRequired = false)]
        public long? VoucherAmount { get; set; }
    }
}