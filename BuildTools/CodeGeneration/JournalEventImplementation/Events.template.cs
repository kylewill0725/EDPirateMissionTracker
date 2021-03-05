using System;
using System.Collections.Generic;
using EliteSharp.Events.Models;
#nullable enable

namespace EliteSharp.Events
{{
    internal class Events : IEvents
    {{
        internal void Invoke(EventBase arg) 
        {{
            switch (arg) 
            {{
                {1}
                default: throw new Exception("Unregistered event invoked"); // Should never happen
            }}
        }}
    
        {0}
    }}
}}