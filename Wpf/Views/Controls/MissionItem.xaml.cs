using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Common;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Wpf.Views
{
    public partial class MissionItem
    {
        public MissionItem()
        {
            InitializeComponent();
            var whiteBrush = new SolidColorBrush(Colors.White);
            var greenBrush = new SolidColorBrush(Colors.Chartreuse);

            this.WhenActivated(disposables =>
            {
                // Wing circle
                this.OneWayBind(ViewModel,
                        vm => vm.Mission.IsWing,
                        view => view.IsWing.Visibility,
                        isWing => isWing ? Visibility.Visible : Visibility.Hidden)
                    .DisposeWith(disposables);

                // Faction name
                this.OneWayBind(ViewModel,
                        vm => vm.Mission.Faction,
                        view => view.FactionName.Text
                    )
                    .DisposeWith(disposables);

                // Mission name
                this.OneWayBind(ViewModel,
                        vm => vm.Mission.Title,
                        view => view.MissionName.Text)
                    .DisposeWith(disposables);

                // Station name
                this.OneWayBind(ViewModel,
                        vm => vm.Mission.Station,
                        view => view.StationName.Text)
                    .DisposeWith(disposables);

                // System name
                this.OneWayBind(ViewModel,
                        vm => vm.Mission.System,
                        view => view.SystemName.Text)
                    .DisposeWith(disposables);

                // Reward
                this.OneWayBind(ViewModel,
                        vm => vm.Mission.Reward,
                        view => view.Reward.Text,
                        reward => $"{reward:C0}")
                    .DisposeWith(disposables);

                // Docked highlighting
                this.OneWayBind(ViewModel,
                        vm => vm.ShouldHighlight,
                        view => view.Grid.Background,
                        isDocked => isDocked ? greenBrush : whiteBrush)
                    .DisposeWith(disposables);
            });
        }
    }

    public class MissionItemViewModel : ReactiveObject
    {
        public Mission Mission { get; }
        public bool ShouldHighlight { [ObservableAsProperty] get; }
        public string ExpiresIn { [ObservableAsProperty] get; }
        public string Progress => $"{(Mission.IsFilled ? "Done " : "")}{Mission.CurrentKills} / {Mission.TotalKills}";

        public MissionItemViewModel(Mission mission, StateTracker state)
        {
            var stationObservable = state.Location;
            Mission = mission;
            stationObservable
                .Select(location => Mission.IsFilled 
                                    && (location.IsDocked 
                                        ? location.Station == mission.Station 
                                        : location.System == mission.System))
                .ObserveOn(RxApp.MainThreadScheduler)
                .ToPropertyEx(this, x => x.ShouldHighlight);

            Observable.Return(1L).Merge(
                    Observable.Interval(TimeSpan.FromSeconds(10))
                )
                .Select(_ =>
                {
                    Mission.Expiry.Subtract(TimeSpan.Zero);
                    return mission.Expiry - DateTime.UtcNow;
                })
                .Select(time => $"Expires in: {time.Days}D {time.Hours}H {time.Minutes}M")
                .ObserveOn(RxApp.MainThreadScheduler)
                .ToPropertyEx(this, x => x.ExpiresIn);
        }
    }
}