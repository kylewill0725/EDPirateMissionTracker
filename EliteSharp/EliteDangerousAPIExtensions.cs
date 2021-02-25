using System;
using System.Collections.Generic;
using EliteSharp.Abstractions;
using EliteSharp.Event.Handler;
using EliteSharp.Event.Module;
using EliteSharp.Event.Processor;
using EliteSharp.Event.Processor.Abstractions;
using EliteSharp.Event.Provider;
using EliteSharp.Event.Provider.Abstractions;
using EliteSharp.Journal.Directory;
using EliteSharp.Journal.Directory.Abstractions;
using EliteSharp.Journal.Processor;
using EliteSharp.Journal.Processor.Abstractions;
using EliteSharp.Journal.Provider;
using EliteSharp.Journal.Provider.Abstractions;
using EliteSharp.Status.Models;
using EliteSharp.Status.Models.Abstractions;
using EliteSharp.Status.Processor;
using EliteSharp.Status.Processor.Abstractions;
using EliteSharp.Status.Provider;
using EliteSharp.Status.Provider.Abstractions;
using Microsoft.Extensions.DependencyInjection;

namespace EliteSharp
{
    public static class EliteDangerousAPIExtensions
    {
        /// <summary>
        ///     Adds all EliteAPI's necessary services to the <seealso cref="IServiceCollection" />
        /// </summary>
        public static IServiceCollection AddEliteAPI(this IServiceCollection services,
            Action<EliteDangerousAPIConfiguration> configuration = null)
        {
            services.AddSingleton<IEliteDangerousAPI, EliteDangerousAPI>();

            services.AddSingleton<IEventProvider, EventProvider>();
            services.AddTransient<IJournalDirectoryProvider, JournalDirectoryProvider>();
            services.AddTransient<IJournalProvider, JournalProvider>();
            services.AddTransient<IStatusProvider, StatusProvider>();

            services.AddSingleton<IJournalProcessor, JournalProcessor>();
            services.AddSingleton<IStatusProcessor, StatusProcessor>();

            services.AddSingleton<IShipStatus, ShipStatus>();

            services.AddSingleton<IEventHandler>();

            var configInstance = new EliteDangerousAPIConfiguration();
            configuration?.Invoke(configInstance);
            configInstance.AddServices(services);

            return services;
        }
    }

    public class EliteDangerousAPIConfiguration
    {
        private readonly IList<Type> eventModuleImplementations;
        private IList<Type> _eventProcessors;

        internal EliteDangerousAPIConfiguration()
        {
            eventModuleImplementations = new List<Type>();
            _eventProcessors = new List<Type>
            {
                typeof(EventsEventProcessor),
                typeof(AttributeEventProcessor),
                typeof(AllEventProcessor)
            };
        }

        /// <summary>
        ///     Add an event module to EliteAPI
        /// </summary>
        /// <typeparam name="T">The event module to be added</typeparam>
        public void AddEventModule<T>() where T : EliteDangerousEventModule
        {
            eventModuleImplementations.Add(typeof(T));
        }

        /// <summary>
        ///     Remove the default event processors
        /// </summary>
        public void ClearProcessors()
        {
            _eventProcessors = new List<Type>();
        }

        /// <summary>
        ///     Adds an event processor
        /// </summary>
        /// <typeparam name="T">The event processor to be used</typeparam>
        public void AddProcessor<T>() where T : IEventProcessor
        {
            _eventProcessors.Add(typeof(T));
        }

        internal void AddServices(IServiceCollection services)
        {
            foreach (var implementation in eventModuleImplementations) services.AddSingleton(implementation);

            foreach (var implementation in _eventProcessors)
                services.AddSingleton(typeof(IEventProcessor), implementation);
        }
    }
}