using System;
using System.Collections.Generic;
using EliteSharp.Events;
using EliteSharp.Events.Models;

namespace EliteSharp
{
    public class EliteSharp
    {
        private EliteSharp()
        {
        }

        public void StartListening()
        {
            
        }
        
        public void StopListening() 
        {
        
        }
        
        public IEnumerable<string> GetCommanders()
        {
            yield return "";
        }

        public EliteSharp ForCommander(string name)
        {
            return this;
        }
        
        public static EliteSharp ListenForEvents()
        {
            return new EliteSharp();
        }

        /// <summary>
        /// This method allows for
        /// </summary>
        /// <param name="predicate"></param>
        /// <returns></returns>
        public static EliteSharp ListenForEventsSinceEvent(Func<EventBase, bool> predicate)
        {
            return new EliteSharp();
        }
    }
}