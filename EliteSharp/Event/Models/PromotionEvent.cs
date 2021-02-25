using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class PromotionEvent : EventBase
    {
        internal PromotionEvent()
        {
        }

        [JsonProperty("Empire")] public long Empire { get; private set; }
    }

    public partial class PromotionEvent
    {
        public static PromotionEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<PromotionEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<PromotionEvent> PromotionEvent;

    }
}