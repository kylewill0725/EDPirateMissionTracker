using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class ModuleInfoEvent : EventBase
    {
        internal ModuleInfoEvent()
        {
        }

    }

    public partial class ModuleInfoEvent
    {
        public static ModuleInfoEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<ModuleInfoEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<ModuleInfoEvent> ModuleInfoEvent;

    }
}