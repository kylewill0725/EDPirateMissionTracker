using System;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using EliteSharp.Journal.Provider.Abstractions;
using Microsoft.Extensions.Logging;

namespace EliteSharp.Journal.Provider
{
    /// <inheritdoc />
    public class JournalProvider : IJournalProvider
    {
        private readonly ILogger<JournalProvider> _log;

        public JournalProvider(ILogger<JournalProvider> logger)
        {
            _log = logger;
        }

        /// <inheritdoc />
        public Task<FileInfo> FindJournalFile(DirectoryInfo journalDirectory)
        {
            try
            {
                return Task.FromResult(journalDirectory
                    .GetFiles("Journal.*.log")
                    .OrderByDescending(file => file.LastWriteTime)
                    .First());
            }
            catch (Exception ex)
            {
                Exception exception = new FileNotFoundException("Could not find journal file", ex);
                _log.LogTrace(exception, "Could not get active journal file from journal directory");
                throw exception;
            }
        }
    }
}