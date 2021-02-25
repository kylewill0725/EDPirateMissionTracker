using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class MusicEvent : EventBase
    {
        internal MusicEvent()
        {
        }

        [JsonProperty("MusicTrack")] public string MusicTrack { get; private set; }
    }

    public partial class MusicEvent
    {
        public static MusicEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<MusicEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<MusicEvent> MusicEvent;

    }
}