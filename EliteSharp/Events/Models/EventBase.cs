using System;
using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public abstract class EventBase
    {
        [DataMember(Name = "timestamp")]
        public DateTimeOffset Timestamp { get; set; }

        [DataMember(Name = "event")]
        public string Event { get; set; }
    }
}