using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class ClearSavedGameEvent : EventBase
    {
        internal ClearSavedGameEvent()
        {
        }

        [JsonProperty("Name")] public string Name { get; private set; }

        [JsonProperty("FID")] public string Fid { get; private set; }
    }

    public partial class ClearSavedGameEvent
    {
        public static ClearSavedGameEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ClearSavedGameEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<ClearSavedGameEvent> ClearSavedGameEvent;

    }
}