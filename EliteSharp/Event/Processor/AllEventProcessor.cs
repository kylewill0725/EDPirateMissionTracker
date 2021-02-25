using System;
using System.Reflection;
using System.Threading.Tasks;
using EliteSharp.Event.Handler;
using EliteSharp.Event.Models.Abstractions;
using EliteSharp.Event.Processor.Abstractions;
using Microsoft.Extensions.Logging;

namespace EliteSharp.Event.Processor
{
    internal class AllEventProcessor : IEventProcessor
    {
        private readonly IEventHandler _eventHandler;
        private readonly ILogger<AllEventProcessor> _log;
        private MethodBase _invokeMethod;

        public AllEventProcessor(ILogger<AllEventProcessor> log, IServiceProvider services, IEventHandler handler)
        {
            _log = log;
            _eventHandler = handler;
        }

        public Task RegisterHandlers()
        {
            return Task.CompletedTask;
        }

        public Task InvokeHandler(EventBase eventBase, bool isWhileCatchingUp)
        {
            try
            {
                _log.LogTrace("Invoking AllEvent for {event}", eventBase.Event);
                _eventHandler.InvokeAllEvent(eventBase);
                return Task.CompletedTask;
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "Could not invoke method for {event}", eventBase.Event);
                return Task.CompletedTask;
            }
        }
    }
}