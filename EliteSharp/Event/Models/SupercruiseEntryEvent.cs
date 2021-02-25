using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class SupercruiseEntryEvent : EventBase
    {
        internal SupercruiseEntryEvent()
        {
        }

        [JsonProperty("StarSystem")] public string StarSystem { get; private set; }

        [JsonProperty("SystemAddress")] public long SystemAddress { get; private set; }
    }

    public partial class SupercruiseEntryEvent
    {
        public static SupercruiseEntryEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<SupercruiseEntryEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<SupercruiseEntryEvent> SupercruiseEntryEvent;

    }
}