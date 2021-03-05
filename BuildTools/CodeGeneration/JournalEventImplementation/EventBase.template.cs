namespace EliteSharp.Events.Models
{{
    using System.Text.RegularExpressions;
    using Utf8Json;
    using System;
    
    public abstract partial class EventBase
    {{
        private static Regex _eventNameParser = new Regex(@"""event"":""(?'eventName'\w+)""");
        static partial void FromJsonImplementation(string json, FromJsonReturn result)
        {{
            var eventName = _eventNameParser.Match(json).Groups["eventName"].Value;
            result.Result = eventName switch
            {{
                {0}
                _ => throw new Exception("Unable to find eventName in json") // TODO: Create exception
            }};
        }}
    }}
}}