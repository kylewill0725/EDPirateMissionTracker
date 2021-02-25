using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class CommanderEvent : EventBase
    {
        internal CommanderEvent()
        {
        }

        [JsonProperty("FID")] public string Fid { get; private set; }

        [JsonProperty("Name")] public string Name { get; private set; }
    }

    public partial class CommanderEvent
    {
        public static CommanderEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<CommanderEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<CommanderEvent> CommanderEvent;

    }
}