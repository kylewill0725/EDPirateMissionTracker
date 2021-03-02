using EliteSharp.Event.Models.Abstractions;

namespace EliteSharp.Journal.Processor.Abstractions
{
    /// <summary>
    ///     A journal entry
    /// </summary>
    public class JournalEntry
    {
        public JournalEntry(EventBase e, bool isWhileCatchingUp)
        {
            Event = e;
            IsWhileCatchingUp = isWhileCatchingUp;
        }

        /// <summary>
        ///     Whether this entry was ran before EliteAPI was started
        /// </summary>
        public bool IsWhileCatchingUp { get; }

        public EventBase Event { get; }
    }
}