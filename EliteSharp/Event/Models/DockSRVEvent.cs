using System;
using EliteSharp.Event.Models.Abstractions;
using Newtonsoft.Json;

namespace EliteSharp.Event.Models
{
    public partial class DockSrvEvent : EventBase
    {
        internal DockSrvEvent()
        {
        }

        [JsonProperty("ID")] public long Id { get; private set; }
    }

    public partial class DockSrvEvent
    {
        public static DockSrvEvent FromJson(string json)
        {
            return JsonConvert.DeserializeObject<DockSrvEvent>(json);
        }
    }

    public partial interface IEventHandler
    {
        public event EventHandler<DockSrvEvent> DockSrvEvent;

    }
}