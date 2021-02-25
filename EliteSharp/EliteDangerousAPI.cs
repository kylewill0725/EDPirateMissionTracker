using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using EliteSharp.Abstractions;
using EliteSharp.Event.Handler;
using EliteSharp.Event.Processor.Abstractions;
using EliteSharp.Event.Provider.Abstractions;
using EliteSharp.Journal.Directory.Abstractions;
using EliteSharp.Journal.Processor.Abstractions;
using EliteSharp.Journal.Provider.Abstractions;
using EliteSharp.Status.Models.Abstractions;
using EliteSharp.Status.Processor.Abstractions;
using EliteSharp.Status.Provider.Abstractions;
using Microsoft.Extensions.Logging;

namespace EliteSharp
{
    /// <inheritdoc />
    public class EliteDangerousAPI : IEliteDangerousAPI
    {
        private readonly IEnumerable<IEventProcessor> _eventProcessors;

        private readonly IEventProvider _eventProvider;

        private readonly IJournalDirectoryProvider _journalDirectoryProvider;
        private readonly IJournalProcessor _journalProcessor;

        private readonly IJournalProvider _journalProvider;

        private readonly ILogger<EliteDangerousAPI> _log;
        private readonly IStatusProcessor _statusProcessor;
        private readonly IStatusProvider _statusProvider;

        /// <summary>
        /// Creates a new EliteDangerousAPI class
        /// </summary>
        /// <param name="services"></param>
        public EliteDangerousAPI(EliteDangerousApiServices services)
        {
            try
            {
                Version = Assembly.GetExecutingAssembly().GetName().Version;
                _eventProcessors = services.EventProcessors;
                _eventProvider = services.EventProvider;
                _journalDirectoryProvider = services.JournalDirectoryProvider;
                _journalProcessor = services.JournalProcessor;
                _journalProvider = services.JournalProvider;
                _log = services.Log;
                _statusProcessor = services.StatusProcessor;
                _statusProvider = services.StatusProvider;
            }
            catch (Exception ex)
            {
                PreInitializationException = ex;
            }
        }

        private DirectoryInfo JournalDirectory { get; set; }
        private FileInfo JournalFile { get; set; }
        private FileInfo StatusFile { get; set; }
        private FileInfo CargoFile { get; set; }
        private FileInfo MarketFile { get; set; }
        private FileInfo OutfittingFile { get; set; }
        private FileInfo ShipyardFile { get; set; }

        private Exception PreInitializationException { get; }
        private Exception InitializationException { get; set; }

        private bool IsInitialized { get; set; }

        /// <inheritdoc />
        public bool IsRunning { get; private set; }

        /// <inheritdoc />
        public bool HasCatchedUp { get; private set; }

        /// <inheritdoc />
        public Version Version { get; }

        /// <inheritdoc />
        public IEventHandler Events { get; }

        /// <inheritdoc />
        public IShipStatus Status { get; }

        /// <inheritdoc />
        public async Task InitializeAsync()
        {
            if (PreInitializationException != null)
            {
                _log?.LogCritical(PreInitializationException, "EliteAPI could not load required services");
                throw PreInitializationException;
            }

            if (IsInitialized) return;

            try
            {
                _log.LogInformation("Initializing EliteAPI v{version}", Version.ToString());

                await CheckComputerOperatingSystem();
                await InitializeEventHandlers();
                await SetJournalDirectory();
                await SetJournalFile();
                await SetSupportFiles();

                _journalProcessor.NewJournalEntry += _journalProcessor_NewJournalEntry;

                _log.LogDebug("EliteAPI has initialized");
            }
            catch (Exception ex)
            {
                _log.LogError(ex, "EliteAPI could not be initialized");
                InitializationException = ex;
            }

            IsInitialized = true;
        }

        /// <inheritdoc />
        public async Task StartAsync()
        {
            if (!IsInitialized) await InitializeAsync();

            if (InitializationException != null)
            {
                _log.LogCritical(InitializationException, "EliteAPI could not be started");
                await StopAsync();
                return;
            }

            IsRunning = true;

            var task = Task.Run(async () =>
            {
                while (IsRunning)
                {
                    await DoTick();
                    await Task.Delay(TimeSpan.FromMilliseconds(500));
                }
            });

            _log.LogInformation("EliteAPI has started");
        }


        /// <inheritdoc />
        public Task StopAsync()
        {
            _journalProcessor.NewJournalEntry -= _journalProcessor_NewJournalEntry;

            IsRunning = false;
            IsInitialized = false;

            return Task.CompletedTask;
        }

        private async Task DoTick()
        {
            try
            {
                await SetSupportFiles();
                await _statusProcessor.ProcessStatusFile(StatusFile);
                await _statusProcessor.ProcessCargoFile(CargoFile);
                await _statusProcessor.ProcessMarketFile(MarketFile);
                await _statusProcessor.ProcessOutfittingFile(OutfittingFile);
                await _statusProcessor.ProcessShipyardFile(ShipyardFile);

                await SetJournalFile();
                await _journalProcessor.ProcessJournalFile(JournalFile, !HasCatchedUp);

                if (!HasCatchedUp)
                {
                    _log.LogInformation("EliteAPI has catched up to current session");
                    HasCatchedUp = true;
                }
            }
            catch (Exception ex)
            {
                _log.LogWarning(ex, "Could not do tick");
            }
        }

        private async Task InitializeEventHandlers()
        {
            foreach (var eventProcessor in _eventProcessors)
                try
                {
                    await eventProcessor.RegisterHandlers();
                }
                catch (Exception ex)
                {
                    _log.LogWarning(ex, "Could not initialize event handler {name}", eventProcessor.GetType().FullName);
                    throw;
                }
        }

        private async void _journalProcessor_NewJournalEntry(object sender, JournalEntry e)
        {
            try
            {
                var eventBase = await _eventProvider.ProcessJsonEvent(e.Json);
                foreach (var eventProcessor in _eventProcessors)
                    await eventProcessor.InvokeHandler(eventBase, e.IsWhileCatchingUp);
            }
            catch (Exception ex)
            {
                _log.LogWarning(ex, "Could not execute event");
            }
        }

        private async Task SetJournalDirectory()
        {
            try
            {
                var newJournalDirectory = await _journalDirectoryProvider.FindJournalDirectory();
                if (newJournalDirectory == null || JournalDirectory?.FullName == newJournalDirectory.FullName) return;

                _log.LogInformation("Setting journal directory to {filePath}", newJournalDirectory.FullName);
                JournalDirectory = newJournalDirectory;
            }
            catch (Exception ex)
            {
                _log.LogWarning(ex, "Could not find journal directory");
                throw;
            }
        }

        private async Task SetJournalFile()
        {
            try
            {
                var newJournalFile = await _journalProvider.FindJournalFile(JournalDirectory);

                if (JournalFile?.FullName == newJournalFile.FullName) return;

                _log.LogInformation("Setting journal file to {filePath}", newJournalFile.Name);
                JournalFile = newJournalFile;
            }
            catch (Exception ex)
            {
                _log.LogWarning(ex, "Could not find the active journal file");
                throw;
            }
        }

        private async Task SetSupportFiles()
        {
            try
            {
                StatusFile = await _statusProvider.FindStatusFile(JournalDirectory);
                CargoFile = await _statusProvider.FindCargoFile(JournalDirectory);
                MarketFile = await _statusProvider.FindMarketFile(JournalDirectory);
                OutfittingFile = await _statusProvider.FindOutfittingFile(JournalDirectory);
                ShipyardFile = await _statusProvider.FindShipyardFile(JournalDirectory);
            }
            catch (Exception ex)
            {
                _log.LogWarning(ex, "Could not set support files");
            }
        }

        private Task CheckComputerOperatingSystem()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
                _log.LogWarning("You are not running on a Windows machine, some features may not work properly");

            return Task.CompletedTask;
        }
    }
}