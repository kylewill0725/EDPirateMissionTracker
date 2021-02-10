using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using EliteAPI.Event.Models.Abstractions;
using EliteAPI.Event.Provider.Abstractions;
using EliteAPI.Exceptions;
using EliteAPI.Journal.Directory.Abstractions;
using EliteAPI.Services.FileReader;

namespace Common
{
    public class JournalReader : IJournalReader
    {
        private readonly IJournalDirectoryProvider _journalDirectoryProvider;
        private readonly IEventProvider _eventProvider;

        public string EventFile { get; set; }

        public JournalReader(IJournalDirectoryProvider journalDirectoryProvider, IEventProvider eventProvider)
        {
            _journalDirectoryProvider = journalDirectoryProvider;
            _eventProvider = eventProvider;
        }

        public IEnumerable<EventBase> ReadAllEvents()
        {
            IEnumerable<EventBase> CreateEnumerable()
            {
                var files =
                    string.IsNullOrWhiteSpace(EventFile)
                        ? from file in _journalDirectoryProvider.FindJournalDirectory().Result.GetFiles("Journal.*.log")
                        orderby file.Name descending
                        select file
                        : new[] {new FileInfo(EventFile), new FileInfo(EventFile)}.AsEnumerable();

                foreach (var file in files.Skip(1))
                {
                    using var fileReader =
                        File.Open(file.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    using var sr = new StreamReader(fileReader);
                    var lines = new List<string>();
                    while (!sr.EndOfStream)
                    {
                        lines.Add(sr.ReadLine()!);
                    }

                    lines.Reverse();
                    foreach (var line in lines)
                    {
                        EventBase? ev = null;
                        try
                        {
                            ev = _eventProvider.ProcessJsonEvent(line).Result;
                        }
                        catch (EventNotImplementedException err)
                        {
                        }

                        if (ev != null)
                            yield return ev;
                    }
                }
            }

            return new EnumerableStream<EventBase>(CreateEnumerable());
        }

        public IEnumerable<EventBase> ReadAllEventsSince(DateTime time)
        {
            IEnumerable<EventBase> CreateEnumerable()
            {
                var fileList = _journalDirectoryProvider.FindJournalDirectory().Result.GetFiles("Journal.*.log");
                var files =
                    string.IsNullOrWhiteSpace(EventFile) ?
                    fileList.SkipWithLastItem(f => f.CreationTimeUtc < time).SkipLast(1)
                    : new []{ new FileInfo(EventFile) };

                foreach (var file in files)
                {
                    using var fileReader =
                        File.Open(file.FullName, FileMode.Open, FileAccess.Read, FileShare.ReadWrite);
                    using var sr = new StreamReader(fileReader);
                    while (!sr.EndOfStream)
                    {
                        var line = sr.ReadLine();
                        EventBase? ev = null;
                        try
                        {
                            ev = _eventProvider.ProcessJsonEvent(line).Result;
                        }
                        catch (EventNotImplementedException)
                        {
                        }

                        if (ev != null && ev.Timestamp >= time)
                            yield return ev;
                    }
                }
            }

            return new EnumerableStream<EventBase>(CreateEnumerable());
        }

        public IJournalReadBuilder TypeOf<T>() where T : EventBase
        {
            return new JournalReadBuilder(this).TypeOf<T>();
        }

        internal IEnumerable<EventBase> ReadEventsWithFilter(Func<EventBase, bool> filterFunc)
        {
            return ReadAllEvents().Where(filterFunc);
        }

        internal IEnumerable<EventBase> ReadEventsSinceWithFilter(DateTime start, Func<EventBase, bool> filterFunc)
        {
            return ReadAllEventsSince(start).Where(filterFunc);
        }
    }

    public class JournalReadBuilder : IJournalReadBuilder
    {
        private readonly JournalReader _reader;
        private Func<EventBase, bool>? _filterFunc;

        internal JournalReadBuilder(JournalReader reader)
        {
            _reader = reader;
        }

        public IJournalReadBuilder TypeOf<T>() where T : EventBase
        {
            _filterFunc =
                _filterFunc switch
                {
                    null => eb => eb is T,
                    { } ff => eb => ff(eb) || eb is T
                };

            return this;
        }

        public IEnumerable<EventBase> ReadEvents()
        {
            var filter = _filterFunc ?? throw new Exception("Something went really wrong.");
            return _reader.ReadEventsWithFilter(filter);
        }

        public IEnumerable<EventBase> ReadEventsSince(DateTime time)
        {
            var filter = _filterFunc ?? throw new Exception("Something went really wrong.");
            return _reader.ReadEventsSinceWithFilter(time, filter);
        }
    }
}