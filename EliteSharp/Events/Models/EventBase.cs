using System;
using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public abstract partial class EventBase
    {
        [DataMember(Name = "timestamp")] public DateTimeOffset Timestamp { get; set; }

        [DataMember(Name = "event")] public string Event { get; set; }
        
        // This is a function generated from the code generator.
        // internal static EventBase FromJson(string json);
        internal static EventBase FromJson(string json)
        {
            var result = new FromJsonReturn();
            FromJsonImplementation(json, result);
            return result.Result ?? throw new Exception("Failed to parse json");
        }
        
        static partial void FromJsonImplementation(string json, FromJsonReturn result);

        private class FromJsonReturn
        {
            public EventBase? Result { get; set; }
        }
    }
}