using System;
using EliteSharp.Event.Models.Abstractions;

namespace EliteSharp.Event.Handler
{
    public partial class EventHandler_old
    {
        public event EventHandler<EventBase> AllEvent;

        internal void InvokeAllEvent(EventBase arg)
        {
            AllEvent?.Invoke(this, arg);
        }
    }
}