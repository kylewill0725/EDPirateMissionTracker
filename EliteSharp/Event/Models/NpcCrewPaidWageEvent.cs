using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class NpcCrewPaidWageEvent : EventBase
    {
        internal NpcCrewPaidWageEvent()
        {
        }

        [JsonProperty("NpcCrewName")] public string NpcCrewName { get; private set; }

        [JsonProperty("NpcCrewId")] public long NpcCrewId { get; private set; }

        [JsonProperty("Amount")] public long Amount { get; private set; }
    }

    public partial class NpcCrewPaidWageEvent
    {
        public static NpcCrewPaidWageEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<NpcCrewPaidWageEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<NpcCrewPaidWageEvent> NpcCrewPaidWageEvent;

    }
}