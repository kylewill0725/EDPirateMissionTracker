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
            Station = new BehaviorSubject<string>("");
            apiEvents.LocationEvent
                .Where(l => l.Docked)
                .Select(l => l.StationName)
                .Merge(apiEvents.DockedEvent.Select(d => d.StationName))
                .Merge(apiEvents.UndockedEvent.Select(_ => ""))
                .Subscribe(x => Station.OnNext(x), _ => {}, () => Station.OnCompleted());
        }

        public BehaviorSubject<string> Station { get; }
    }
}