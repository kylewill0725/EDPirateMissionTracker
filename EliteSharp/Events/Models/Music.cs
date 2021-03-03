using System.Runtime.Serialization;

namespace EliteSharp.Events.Models
{
    public class Music : EventBase
    {
        public enum MusicTrackEnum
        {
            [DataMember(Name = "Codex")] Codex,
            [DataMember(Name = "Combat_Dogfight")] CombatDogfight,

            [DataMember(Name = "Combat_LargeDogFight")]
            CombatLargeDogFight,

            [DataMember(Name = "DestinationFromHyperspace")]
            DestinationFromHyperspace,

            [DataMember(Name = "DestinationFromSupercruise")]
            DestinationFromSupercruise,
            [DataMember(Name = "DockingComputer")] DockingComputer,
            [DataMember(Name = "Exploration")] Exploration,

            [DataMember(Name = "FleetCarrier_Managment")]
            FleetCarrierManagment,
            [DataMember(Name = "GalaxyMap")] GalaxyMap,
            [DataMember(Name = "Interdiction")] Interdiction,
            [DataMember(Name = "MainMenu")] MainMenu,
            [DataMember(Name = "NoInGameMusic")] NoInGameMusic,
            [DataMember(Name = "NoTrack")] NoTrack,
            [DataMember(Name = "Starport")] Starport,
            [DataMember(Name = "Supercruise")] Supercruise,

            [DataMember(Name = "SystemAndSurfaceScanner")]
            SystemAndSurfaceScanner,
            [DataMember(Name = "SystemMap")] SystemMap
        }

        [DataMember(Name = "MusicTrack")] public MusicTrackEnum MusicTrack { get; set; }
    }
}