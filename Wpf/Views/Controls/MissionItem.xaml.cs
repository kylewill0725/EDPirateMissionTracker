using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using Common;
using ReactiveUI;

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

                // Progress
                this.OneWayBind(ViewModel,
                        vm => vm.Progress,
                        view => view.Progress.Text)
                    .DisposeWith(disposables);

                // Expire text
                this.OneWayBind(ViewModel,
                        vm => vm.ExpiresIn,
                        view => view.Expiration.Text)
                    .DisposeWith(disposables);

                // Docked highlighting
                this.OneWayBind(ViewModel,
                        vm => vm.IsDockedAtMissionStation,
                        view => view.Grid.Background,
                        isDocked => isDocked ? greenBrush : whiteBrush)
                    .DisposeWith(disposables);
            });
        }
    }

    public class MissionItemViewModel : ReactiveObject
    {
        public Mission Mission { get; }

        private readonly ObservableAsPropertyHelper<bool> _isDockedAtMissionStation;
        public bool IsDockedAtMissionStation => _isDockedAtMissionStation.Value;

        private readonly ObservableAsPropertyHelper<string> _expiresIn;
        public string ExpiresIn => _expiresIn.Value;
        public string Progress => $"{(Mission.IsFilled ? "Done " : "")}{Mission.CurrentKills} / {Mission.TotalKills}";

        public MissionItemViewModel(Mission mission, StateTracker state)
        {
            var stationObservable = state.Station;
            Mission = mission;
            _isDockedAtMissionStation =
                stationObservable
                    .Select(station => Mission.IsFilled && station == Mission.Station)
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .ToProperty(this, x => x.IsDockedAtMissionStation);

            _expiresIn =
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
                    .ToProperty(this, x => x.ExpiresIn);
        }
    }
}