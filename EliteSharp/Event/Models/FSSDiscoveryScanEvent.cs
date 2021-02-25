using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class FssDiscoveryScanEvent : EventBase
    {
        internal FssDiscoveryScanEvent()
        {
        }

        [JsonProperty("Progress")] public double Progress { get; private set; }

        [JsonProperty("BodyCount")] public long BodyCount { get; private set; }

        [JsonProperty("NonBodyCount")] public long NonBodyCount { get; private set; }
    }

    public partial class FssDiscoveryScanEvent
    {
        public static FssDiscoveryScanEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<FssDiscoveryScanEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<FssDiscoveryScanEvent> FssDiscoveryScanEvent;

    }
}