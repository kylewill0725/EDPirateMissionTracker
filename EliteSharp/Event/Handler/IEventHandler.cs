using EliteSharp.Event.Models.Abstractions;

namespace EliteSharp.Event.Handler
{
    public partial interface IEventHandler
    {
        void InvokeAllEvent(EventBase eventBase);
    }
}