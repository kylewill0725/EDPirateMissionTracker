using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class UssDropEvent : EventBase
    {
        internal UssDropEvent()
        {
        }

        [JsonProperty("USSType")] public string UssType { get; private set; }

        [JsonProperty("USSType_Localised")] public string UssTypeLocalised { get; private set; }

        [JsonProperty("USSThreat")] public long UssThreat { get; private set; }
    }

    public partial class UssDropEvent
    {
        public static UssDropEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<UssDropEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<UssDropEvent> UssDropEvent;

    }
}