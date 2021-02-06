using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows;
using Common;
using EliteAPI.Abstractions;
using EliteAPI.Event.Handler;
using EliteAPI.Event.Models;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;

namespace Wpf.ViewModels
{
    public class MainWindowViewModel : ReactiveObject, IScreen, IActivatableViewModel
    {
        public ViewModelActivator Activator { get; }
        public RoutingState Router { get; }
        
        private readonly ObservableAsPropertyHelper<bool> _doneLoading;
        public bool DoneLoading => _doneLoading.Value;

        public MainWindowViewModel(IEliteDangerousApi api, MissionCatchUp missionCatchUp)
        {
            Router = new RoutingState();
            Activator = new ViewModelActivator();

            missionCatchUp.CatchUp();
            
            _doneLoading = api.Events().OnCatchedUp
                .Select(_ => true)
                .ObserveOn(RxApp.MainThreadScheduler)
                .ToProperty(this, x => x.DoneLoading);

            // Change what is showing
            var eliteEvents = api.Events.Events();
            this.WhenActivated((CompositeDisposable disposables) =>
            {
                
                eliteEvents
                    .LocationEvent
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Select<LocationEvent, IRoutableViewModel>(e =>
                        true
                            ? ((App) Application.Current).Services.GetService<DockedViewModel>()!
                            : ((App) Application.Current).Services.GetService<CombatViewModel>()!
                    )
                    .Do(vm => Router.Navigate.Execute(vm))
                    .Subscribe(_ => { })
                    .DisposeWith(disposables);

                eliteEvents
                    .UndockedEvent
                    .Where(_ => CaughtUp)
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Do(_ => Router.Navigate.Execute(((App) Application.Current).Services
                        .GetService<CombatViewModel>()))
                    .Subscribe(_ => { })
                    .DisposeWith(disposables);

                eliteEvents
                    .DockedEvent
                    .Where(_ => CaughtUp)
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Do(_ => Router.Navigate.Execute(((App) Application.Current).Services
                        .GetService<DockedViewModel>()))
                    .Subscribe(_ => { })
                    .DisposeWith(disposables);
            });

            api.StartAsync();
        }

        public bool CaughtUp { get; set; }
    }
}