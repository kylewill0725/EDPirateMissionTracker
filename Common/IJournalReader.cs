using System;
using System.Collections.Generic;
using EliteAPI.Event.Models.Abstractions;

namespace Common
{
    public interface IJournalReader
    {
        /// <summary>
        /// Reads events from the journal from newest to oldest.
        /// </summary>
        /// <returns></returns>
        IEnumerable<EventBase> ReadAllEvents();
        
        /// <summary>
        /// Reads events from the journal from oldest to newest starting at time
        /// </summary>
        /// <param name="time"></param>
        /// <returns></returns>
        IEnumerable<EventBase> ReadAllEventsSince(DateTime time);

        /// <summary>
        /// Applies a type filter to events
        /// </summary>
        /// <typeparam name="T">EliteAPI event to look for</typeparam>
        /// <returns></returns>
        IJournalReadBuilder TypeOf<T>() where T : EventBase;
    }

    public interface IJournalReadBuilder
    {
        IJournalReadBuilder TypeOf<T>() where T : EventBase;
        IEnumerable<EventBase> ReadEvents();
        IEnumerable<EventBase> ReadEventsSince(DateTime time);
    }
}