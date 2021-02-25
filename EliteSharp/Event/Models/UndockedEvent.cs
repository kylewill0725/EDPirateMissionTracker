using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class UndockedEvent : EventBase
    {
        internal UndockedEvent()
        {
        }

        [JsonProperty("StationName")] public string StationName { get; private set; }

        [JsonProperty("StationType")] public string StationType { get; private set; }

        [JsonProperty("MarketID")] public long MarketId { get; private set; }
    }

    public partial class UndockedEvent
    {
        public static UndockedEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<UndockedEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<UndockedEvent> UndockedEvent;

    }
}