using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows;
using Common;
using EliteAPI.Abstractions;
using EliteAPI.Event.Handler;
using Microsoft.Extensions.DependencyInjection;
using ReactiveUI;

namespace Wpf.ViewModels
{
    public class MainWindowViewModel : ReactiveObject, IScreen, IActivatableViewModel
    {
        private readonly IEliteDangerousApi _api;
        private readonly MissionTargetManager _missionTargetManager;
        public ViewModelActivator Activator { get; }

        public RoutingState Router { get; }
        
        public MainWindowViewModel(IEliteDangerousApi api, MissionTargetManager missionTargetManager, MissionCatchUp missionCatchUp)
        {
            _api = api;
            _missionTargetManager = missionTargetManager;

            Router = new RoutingState();
            Activator = new ViewModelActivator();
            
            missionCatchUp.CatchUp();
            
            // Change what is showing
            var eliteEvents = _api.Events.Events();
            this.WhenActivated(disposables =>
            {
                eliteEvents
                    .UndockedEvent
                    .Where(_ => CaughtUp)
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Do(_ => Router.Navigate.Execute(((App)Application.Current).Services.GetService<CombatViewModel>()))
                    .Subscribe(x => { })
                    .DisposeWith(disposables);
                
                eliteEvents
                    .DockedEvent
                    .Where(_ => CaughtUp)
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Do(_ => Router.Navigate.Execute(((App)Application.Current).Services.GetService<DockedViewModel>()))
                    .Subscribe(x => { })
                    .DisposeWith(disposables);
                
                // api.Events()
                //     .OnCatchedUp
                    
            });

            api.StartAsync();
        }

        public bool CaughtUp { get; set; }
    }
}