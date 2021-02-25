using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using EliteSharp.Event.Handler;
using EliteSharp.Event.Models.Abstractions;
using EliteSharp.Event.Processor.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace EliteSharp.Event.Processor
{
    /// <inheritdoc />
    public class EventsEventProcessor : MethodEventProcessorBase
    {
        private readonly Assembly _assembly;

        private readonly ILogger<EventsEventProcessor> _log;
        private readonly IServiceProvider _services;
        private IEventHandler _eventHandler;

        public EventsEventProcessor(ILogger<EventsEventProcessor> log, IServiceProvider services) : base(log, services)
        {
            _assembly = Assembly.GetExecutingAssembly();
            _log = log;
            _services = services;
            _eventHandler = services.GetRequiredService<IEventHandler>();
        }

        /// <inheritdoc />
        public override async Task RegisterHandlers()
        {
            try
            {
                _log.LogDebug("Detecting event handlers");
                var s = Stopwatch.StartNew();

                Cache = new ConcurrentDictionary<string, IEnumerable<MethodBase>>();

                var eventHandler = typeof(IEventHandler);

                var eventTypes = GetAllEventTypes().ToList();
                var invokeMethods = GetAllInvokeMethods(eventHandler).ToList();
                var totalHandlers = 0;

                foreach (var eventType in eventTypes)
                {
                    var validMethods = GetAllInvokeMethodsForEvent(invokeMethods, eventType.Name).ToList();

                    if (validMethods.Any())
                    {
                        totalHandlers += validMethods.Count;
                        _log.LogTrace("Registering {eventName} to {eventNameSpace}",
                            eventType.Name, validMethods.Select(x => $"{x.DeclaringType?.FullName}.{x.Name}"));
                        Cache.Add(eventType.Name, validMethods);
                    }
                }

                s.Stop();
                _log.LogDebug("{eventCount} event-handlers were registered in {time}ms", totalHandlers,
                    s.ElapsedMilliseconds);
            }
            catch (Exception ex)
            {
                _log.LogTrace(ex, "Could not register event handlers");
                throw;
            }
        }

        private IEnumerable<Type> GetAllEventTypes()
        {
            var eventTypes = _assembly.GetTypes()
                .Where(x => x.IsSubclassOf(typeof(EventBase)) && x.IsClass && !x.IsAbstract);

            return eventTypes;
        }

        private IEnumerable<MethodBase> GetAllInvokeMethods(Type eventHandler)
        {
            return eventHandler.GetMethods(BindingFlags.Instance
                                           | BindingFlags.NonPublic
                                           | BindingFlags.Public
                                           | BindingFlags.Static)
                .Where(MethodIsValidInvokeMethod);
        }

        private IEnumerable<MethodBase> GetAllInvokeMethodsForEvent(IEnumerable<MethodBase> methods, string eventName)
        {
            return methods.Where(x => eventName.StartsWith(x.GetParameters().First().ParameterType.Name));
        }

        private bool MethodIsValidInvokeMethod(MethodBase method)
        {
            return !method.Name.StartsWith("add_")
                   && !method.Name.StartsWith("remove_")
                   && method.GetParameters().Length > 0
                   && method.GetParameters().First().ParameterType.IsSubclassOf(typeof(EventBase));
        }
    }
}