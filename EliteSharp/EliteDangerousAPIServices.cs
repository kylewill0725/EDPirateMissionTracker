using System.Collections.Generic;
using EliteSharp.Event.Processor.Abstractions;
using EliteSharp.Event.Provider.Abstractions;
using EliteSharp.Journal.Directory.Abstractions;
using EliteSharp.Journal.Processor.Abstractions;
using EliteSharp.Journal.Provider.Abstractions;
using EliteSharp.Status.Processor.Abstractions;
using EliteSharp.Status.Provider.Abstractions;
using Microsoft.Extensions.Logging;

namespace EliteSharp
{
    public class EliteDangerousApiServices
    {
        public EliteDangerousApiServices(IEnumerable<IEventProcessor> eventProcessors, IEventProvider eventProvider,
            IJournalDirectoryProvider journalDirectoryProvider, IJournalProcessor journalProcessor,
            IJournalProvider journalProvider, ILogger<EliteDangerousAPI> log, IStatusProcessor statusProcessor,
            IStatusProvider statusProvider)
        {
            EventProvider = eventProvider;
            JournalDirectoryProvider = journalDirectoryProvider;
            JournalProcessor = journalProcessor;
            JournalProvider = journalProvider;
            Log = log;
            StatusProcessor = statusProcessor;
            StatusProvider = statusProvider;
            EventProcessors = eventProcessors;
        }

        public IEnumerable<IEventProcessor> EventProcessors { get; private set; }
        public IEventProvider EventProvider { get; private set; }

        public IJournalDirectoryProvider JournalDirectoryProvider { get; private set; }
        public IJournalProcessor JournalProcessor { get; private set; }

        public IJournalProvider JournalProvider { get; private set; }

        public ILogger<EliteDangerousAPI> Log { get; private set; }
        public IStatusProcessor StatusProcessor { get; private set; }
        public IStatusProvider StatusProvider { get; private set; }
    }
}