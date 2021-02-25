using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class ScreenshotEvent : EventBase
    {
        internal ScreenshotEvent()
        {
        }

        [JsonProperty("Filename")] public string Filename { get; private set; }

        [JsonProperty("Width")] public long Width { get; private set; }

        [JsonProperty("Height")] public long Height { get; private set; }

        [JsonProperty("System")] public string System { get; private set; }

        [JsonProperty("Body")] public string Body { get; private set; }
    }

    public partial class ScreenshotEvent
    {
        public static ScreenshotEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ScreenshotEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<ScreenshotEvent> ScreenshotEvent;

    }
}