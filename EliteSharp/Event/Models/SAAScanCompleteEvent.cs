using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class SaaScanCompleteEvent : EventBase
    {
        internal SaaScanCompleteEvent()
        {
        }

        [JsonProperty("BodyName")] public string BodyName { get; private set; }

        [JsonProperty("BodyID")] public long BodyId { get; private set; }

        [JsonProperty("ProbesUsed")] public long ProbesUsed { get; private set; }

        [JsonProperty("EfficiencyTarget")] public long EfficiencyTarget { get; private set; }
    }

    public partial class SaaScanCompleteEvent
    {
        public static SaaScanCompleteEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SaaScanCompleteEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<SaaScanCompleteEvent> SaaScanCompleteEvent;

    }
}