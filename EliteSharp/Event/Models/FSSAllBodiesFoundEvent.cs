using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class FssAllBodiesFoundEvent : EventBase
    {
        internal FssAllBodiesFoundEvent()
        {
        }

        [JsonProperty("SystemName")] public string SystemName { get; private set; }

        [JsonProperty("SystemAddress")] public long SystemAddress { get; private set; }

        [JsonProperty("Count")] public long Count { get; private set; }
    }

    public partial class FssAllBodiesFoundEvent
    {
        public static FssAllBodiesFoundEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<FssAllBodiesFoundEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<FssAllBodiesFoundEvent> FssAllBodiesFoundEvent;

    }
}