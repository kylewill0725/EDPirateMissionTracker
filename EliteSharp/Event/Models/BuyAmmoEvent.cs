using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class BuyAmmoEvent : EventBase
    {
        internal BuyAmmoEvent()
        {
        }

        [JsonProperty("Cost")] public long Cost { get; private set; }
    }

    public partial class BuyAmmoEvent
    {
        public static BuyAmmoEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<BuyAmmoEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<BuyAmmoEvent> BuyAmmoEvent;

    }
}