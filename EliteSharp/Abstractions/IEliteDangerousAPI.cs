using System;
using System.Threading.Tasks;
using EliteSharp.Event.Handler;
using EliteSharp.Status.Models.Abstractions;

namespace EliteSharp.Abstractions
{
    /// <summary>
    ///     EliteAPI
    /// </summary>
    public interface IEliteDangerousAPI
    {
        /// <summary>
        ///     EliteAPI's version
        /// </summary>
        Version Version { get; }

        /// <summary>
        ///     Container for all events
        /// </summary>
        IEventHandler Events { get; }

        /// <summary>
        ///     Container for the ship's current status
        /// </summary>
        IShipStatus Status { get; }

        /// <summary>
        ///     Whether the api is currently running
        /// </summary>
        bool IsRunning { get; }

        /// <summary>
        ///     Whether the api has catched up on past event in this session
        /// </summary>
        bool HasCatchedUp { get; }

        /// <summary>
        ///     Initializes the api
        /// </summary>
        Task InitializeAsync();

        /// <summary>
        ///     Starts the api
        /// </summary>
        Task StartAsync();

        /// <summary>
        ///     Stops the api
        /// </summary>
        Task StopAsync();
    }
}