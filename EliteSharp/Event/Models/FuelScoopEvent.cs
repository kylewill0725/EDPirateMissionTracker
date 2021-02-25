using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class FuelScoopEvent : EventBase
    {
        internal FuelScoopEvent()
        {
        }

        [JsonProperty("Scooped")] public double Scooped { get; private set; }

        [JsonProperty("Total")] public double Total { get; private set; }
    }

    public partial class FuelScoopEvent
    {
        public static FuelScoopEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<FuelScoopEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<FuelScoopEvent> FuelScoopEvent;

    }
}