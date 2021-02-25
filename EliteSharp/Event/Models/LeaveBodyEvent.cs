using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class LeaveBodyEvent : EventBase
    {
        internal LeaveBodyEvent()
        {
        }

        [JsonProperty("StarSystem")] public string StarSystem { get; private set; }

        [JsonProperty("SystemAddress")] public long SystemAddress { get; private set; }

        [JsonProperty("Body")] public string Body { get; private set; }

        [JsonProperty("BodyID")] public long BodyId { get; private set; }
    }

    public partial class LeaveBodyEvent
    {
        public static LeaveBodyEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<LeaveBodyEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<LeaveBodyEvent> LeaveBodyEvent;

    }
}