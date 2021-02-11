using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Threading.Tasks;
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
            MissionTargetManager missionTargetManager, StateTracker tracker)
        {
            Router = new RoutingState();
            Activator = new ViewModelActivator();

            api.Events().OnCatchedUp
                .Select(_ => true)
                .ObserveOn(RxApp.MainThreadScheduler)
                .ToPropertyEx(this, x => x.DoneLoading);

            // Change what is showing
            this.WhenActivated(disposables =>
            {
                var filledMissionCountChanged =
                    missionTargetManager
                        .Connect()
                        .Group(mission => (mission.System, mission.Station))
                        .Transform(g => new StationMissionsGroup(g))
                        .DisposeMany()
                        .ObserveOn(RxApp.MainThreadScheduler)
                        .Bind(out var stationMissions);

                tracker.Location
                    .CombineLatest(filledMissionCountChanged.WhenPropertyChanged(x => x.MissionCount), (dockedLocation, _) => dockedLocation)
                    .CombineLatest(api.Events().OnCatchedUp.Delay(TimeSpan.FromMilliseconds(50)), (location, _) => location)
                    .Where(_ => DoneLoading)
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Select(e =>
                        {
                            bool showTurnIn;
                            if (e.IsDocked)
                            {
                                showTurnIn = stationMissions.Any(sm =>
                                    sm.HasFilled
                                    && sm.Station == e.Station);
                            }
                            else
                            {
                                showTurnIn =
                                    stationMissions.Any(sm =>
                                        sm.HasFilled
                                        && sm.System == e.System
                                    );
                            }

                            return showTurnIn
                                // true
                                ? (IRoutableViewModel) ((App) Application.Current).Services
                                .GetService<TurnInViewModel>()!
                                : (IRoutableViewModel) ((App) Application.Current).Services
                                .GetService<MissionStatsViewModel>()!;
                        }
                    )
                    .Do(vm => Router.Navigate.Execute(vm))
                    .Subscribe(_ => { })
                    .DisposeWith(disposables);
            });

            Task.Run(() =>
            {
                missionCatchUp.CatchUp();
                api.StartAsync();
            });
        }
    }

    public class StationMissionsGroup : AbstractNotifyPropertyChanged, IDisposable
    {
        private IDisposable _cleanup;
        private int _missionCount;
        private bool _hasFilled;

        public StationMissionsGroup(IGroup<Mission, string, (string System, string Station)> grouping)
        {
            System = grouping.Key.System;
            Station = grouping.Key.Station;
            var missionCountSetter =
                grouping.Cache.CountChanged
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Subscribe(count => MissionCount = count);
            var hasFilledSetter =
                grouping.Cache.Connect()
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Bind(out var missions)
                    .Select(_ =>
                    {
                        return missions.Any(m => m.IsFilled);
                    })
                    .Subscribe(hasFilled => HasFilled = hasFilled);

            _cleanup = new CompositeDisposable(missionCountSetter, hasFilledSetter);
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
        public string System { get; }

        public void Dispose()
        {
            _cleanup.Dispose();
        }
    }
}