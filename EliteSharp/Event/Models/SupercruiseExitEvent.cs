using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class SupercruiseExitEvent : EventBase
    {
        internal SupercruiseExitEvent()
        {
        }

        [JsonProperty("StarSystem")] public string StarSystem { get; private set; }

        [JsonProperty("SystemAddress")] public long SystemAddress { get; private set; }

        [JsonProperty("Body")] public string Body { get; private set; }

        [JsonProperty("BodyID")] public long BodyId { get; private set; }

        [JsonProperty("BodyType")] public string BodyType { get; private set; }
    }

    public partial class SupercruiseExitEvent
    {
        public static SupercruiseExitEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SupercruiseExitEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<SupercruiseExitEvent> SupercruiseExitEvent;

    }
}