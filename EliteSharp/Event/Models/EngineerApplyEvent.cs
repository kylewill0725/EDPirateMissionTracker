using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class EngineerApplyEvent : EventBase
    {
        internal EngineerApplyEvent()
        {
        }

        [JsonProperty("Engineer")] public string Engineer { get; private set; }

        [JsonProperty("Blueprint")] public string Blueprint { get; private set; }

        [JsonProperty("Level")] public long Level { get; private set; }
    }

    public partial class EngineerApplyEvent
    {
        public static EngineerApplyEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<EngineerApplyEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<EngineerApplyEvent> EngineerApplyEvent;

    }
}