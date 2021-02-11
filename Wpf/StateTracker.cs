using System;
using System.Reactive.Linq;
using System.Reactive.Subjects;
using EliteAPI.Abstractions;
using EliteAPI.Event.Handler;

namespace Wpf
{
    public class StateTracker
    {
        public StateTracker(IEliteDangerousApi api)
        {
            var apiEvents = api.Events.Events();
            
            apiEvents.DockedEvent.Select(d => new DockedUpdate(true, d.StationName))
                .Merge(apiEvents.LocationEvent
                    .Where(l => l.Docked)
                    .Select(l => new DockedUpdate(l.Docked, l.StationName)))
                .Merge(apiEvents.UndockedEvent.Select(_ => new DockedUpdate(false, "")))
                .Subscribe(x =>
                {
                    Station.OnNext(x.Station);
                    IsDocked.OnNext(x.IsDocked);
                }, _ => {}, () =>
                {
                    Station.OnCompleted();
                    IsDocked.OnCompleted();
                });
            
            apiEvents.FsdJumpEvent.Select(d => d.StarSystem)
                .Merge(apiEvents.LocationEvent.Select(l => l.StarSystem))
                .Subscribe(x => System.OnNext(x), _ => {}, () => System.OnCompleted());

            Location =
                Station
                    .CombineLatest(System, (station, system) => (station, system))
                    .CombineLatest(IsDocked,
                        (stationUpdate, isDocked) =>
                            new LocationUpdate(isDocked, stationUpdate.system, stationUpdate.station));
        }

        public IObservable<LocationUpdate> Location { get; }

        public BehaviorSubject<string> Station { get; } = new("");
        public BehaviorSubject<string> System { get; } = new("");
        public BehaviorSubject<bool> IsDocked { get; } = new(false);

        private record DockedUpdate(bool IsDocked, string Station);
    }

    public record LocationUpdate(bool IsDocked, string System, string Station);
}