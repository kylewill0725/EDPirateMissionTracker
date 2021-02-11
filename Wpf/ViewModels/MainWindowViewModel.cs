using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows;
using Common;
using DynamicData;
using DynamicData.Alias;
using DynamicData.Binding;
using EliteAPI.Abstractions;
using EliteAPI.Event.Handler;
using EliteAPI.Event.Models;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Wpf.ViewModels
{
    public class MainWindowViewModel : ReactiveObject, IScreen, IActivatableViewModel
    {
        public ViewModelActivator Activator { get; }
        public RoutingState Router { get; }
        public bool DoneLoading { [ObservableAsProperty] get; }

        public MainWindowViewModel(IEliteDangerousApi api, MissionCatchUp missionCatchUp,
            MissionTargetManager missionTargetManager)
        {
            Router = new RoutingState();
            Activator = new ViewModelActivator();

            missionCatchUp.CatchUp();

            api.Events().OnCatchedUp
                .Select(_ => true)
                .ObserveOn(RxApp.MainThreadScheduler)
                .ToPropertyEx(this, x => x.DoneLoading);

            // Change what is showing
            var eliteEvents = api.Events.Events();
            this.WhenActivated((CompositeDisposable disposables) =>
            {
                var filledMissionCountChanged =
                    missionTargetManager
                        .Connect()
                        .Group(mission => mission.Station)
                        .Transform(g => new StationMissionsGroup(g))
                        .DisposeMany()
                        .ObserveOn(RxApp.MainThreadScheduler);


                var initialLocation =
                    eliteEvents
                        .LocationEvent
                        .Select(l => new DockedLocationPair(l.Docked, l.StationName))
                        .ObserveOn(RxApp.MainThreadScheduler);

                var undocked =
                    eliteEvents
                        .UndockedEvent
                        .Select(d => new DockedLocationPair(false, ""))
                        .ObserveOn(RxApp.MainThreadScheduler);

                var docked =
                    eliteEvents
                        .DockedEvent
                        .Select(d => new DockedLocationPair(true, d.StationName))
                        .ObserveOn(RxApp.MainThreadScheduler);

                initialLocation
                    .Merge(undocked)
                    .Merge(docked)
                    .CombineLatest(filledMissionCountChanged,
                        (dockedLocation, change) => new LocationChangePair(dockedLocation, change))
                    .Delay(_ => api.Events().OnCatchedUp.ObserveOn(RxApp.MainThreadScheduler))
                    .Select(e => {
                        var condition =
                        e.Location.IsDocked
                        && e.StationMissionInfo.Any(x =>
                            x.Current.MissionCount > 0
                            && x.Current.HasFilled
                            && x.Current.Station == e.Location.StationName);
                        return condition
                            // true
                            ? (IRoutableViewModel)((App)Application.Current).Services
                            .GetService<TurnInViewModel>()!
                            : (IRoutableViewModel)((App)Application.Current).Services
                            .GetService<MissionStatsViewModel>()!;
                            }
                    )
                    .Do(vm => Router.Navigate.Execute(vm))
                    .Subscribe(_ => { })
                    .DisposeWith(disposables);
            });

            api.StartAsync();
        }

        private record DockedLocationPair(bool IsDocked, string StationName);

        private record LocationChangePair(DockedLocationPair Location,
            IChangeSet<StationMissionsGroup, string> StationMissionInfo);
    }


    public class StationMissionsGroup : AbstractNotifyPropertyChanged, IDisposable
    {
        private IDisposable _cleanup;
        private int _missionCount;
        private bool _hasFilled;

        public StationMissionsGroup(IGroup<Mission, string, string> grouping)
        {
            Station = grouping.Key;
            var missionCountSetter =
                grouping.Cache.CountChanged
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Subscribe(count => MissionCount = count);
            var test =
                grouping.Cache.Connect()
                    .Select(cs => cs.Any(x => x.Current.IsFilled))
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Subscribe(hasFilled => HasFilled = hasFilled);

            _cleanup = new CompositeDisposable(missionCountSetter, test);
        }

        public int MissionCount
        {
            get => _missionCount;
            private set => SetAndRaise(ref _missionCount, value);
        }

        public bool HasFilled
        {
            get => _hasFilled;
            private set => SetAndRaise(ref _hasFilled, value);
        }

        public string Station { get; }

        public void Dispose()
        {
            _cleanup.Dispose();
        }
    }
}