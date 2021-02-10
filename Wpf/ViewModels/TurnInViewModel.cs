using System;
using System.Collections.ObjectModel;
using System.Reactive.Linq;
using Common;
using DynamicData;
using DynamicData.Binding;
using ReactiveUI;
using Wpf.Views;

namespace Wpf.ViewModels
{
    public class TurnInViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment { get; } = "Docked";
        private readonly ReadOnlyObservableCollection<MissionItemViewModel> _missions;
        public ReadOnlyObservableCollection<MissionItemViewModel> Missions => _missions;
        
        public IScreen HostScreen { get; }

        public TurnInViewModel(IScreen hostScreen, MissionTargetManager missionTargetManager, StateTracker state)
        {
            HostScreen = hostScreen;
            var comparer = SortExpressionComparer<Mission>.Descending(m => m.IsWing).ThenByDescending(m => m.IsFilled).ThenByDescending(m => m.MissionId);
            missionTargetManager
                .Connect()
                .Sort(comparer)
                .Transform(m => new MissionItemViewModel(m, state))
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(out _missions)
                .Subscribe();
        }
    }
}