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
                        .Where(m => m.IsFilled)
                        .ObserveOn(RxApp.MainThreadScheduler)
                        .Bind(out var stationMissions)
                        .DisposeMany();

                tracker.Location
                    .CombineLatest(filledMissionCountChanged, (dockedLocation, _) => dockedLocation)
                    .CombineLatest(api.Events().OnCatchedUp.Delay(TimeSpan.FromMilliseconds(50)),
                        (location, _) => location)
                    .Where(_ => DoneLoading)
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Select(e =>
                        {
                            var showTurnIn = 
                                e.IsDocked 
                                    ? stationMissions.Any(m => m.Station == e.Station) 
                                    : stationMissions.Any(m => m.System == e.System);

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
}