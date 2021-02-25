using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class FileheaderEvent : EventBase
    {
        internal FileheaderEvent()
        {
        }

        [JsonProperty("part")] public long Part { get; private set; }

        [JsonProperty("language")] public string Language { get; private set; }

        [JsonProperty("gameversion")] public string Gameversion { get; private set; }

        [JsonProperty("build")] public string Build { get; private set; }
    }

    public partial class FileheaderEvent
    {
        public static FileheaderEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<FileheaderEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<FileheaderEvent> FileheaderEvent;

    }
}