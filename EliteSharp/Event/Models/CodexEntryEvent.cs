using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class CodexEntryEvent : EventBase
    {
        internal CodexEntryEvent()
        {
        }

        [JsonProperty("EntryID")] public long EntryId { get; private set; }

        [JsonProperty("Name")] public string Name { get; private set; }

        [JsonProperty("Name_Localised")] public string NameLocalised { get; private set; }

        [JsonProperty("SubCategory")] public string SubCategory { get; private set; }

        [JsonProperty("SubCategory_Localised")]
        public string SubCategoryLocalised { get; private set; }

        [JsonProperty("Category")] public string Category { get; private set; }

        [JsonProperty("Category_Localised")] public string CategoryLocalised { get; private set; }

        [JsonProperty("Region")] public string Region { get; private set; }

        [JsonProperty("Region_Localised")] public string RegionLocalised { get; private set; }

        [JsonProperty("System")] public string System { get; private set; }

        [JsonProperty("SystemAddress")] public long SystemAddress { get; private set; }

        [JsonProperty("IsNewEntry")] public bool IsNewEntry { get; private set; }
    }

    public partial class CodexEntryEvent
    {
        public static CodexEntryEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CodexEntryEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<CodexEntryEvent> CodexEntryEvent;

    }
}