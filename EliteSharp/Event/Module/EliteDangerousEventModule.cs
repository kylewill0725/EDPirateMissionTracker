﻿
namespace EliteSharp.Event.Module
{
    /// <summary>
    /// Wrapper for event modules
    /// </summary>
    public abstract class EliteDangerousEventModule
    {
        /// <summary>
        /// The Elite Dangerous API
        /// </summary>
        // protected readonly IEliteDangerousAPI EliteAPI;

        /// <summary>
        /// Wrapper for event modules
        /// </summary>
        /// <param name="api">The EliteDangerousAPI</param>
        protected EliteDangerousEventModule(/*IEliteDangerousAPI api*/)
        {
            // EliteAPI = api;
        }
    }
}