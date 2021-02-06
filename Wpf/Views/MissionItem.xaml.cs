using System;
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
                    isWing => isWing ? Visibility.Visible : Visibility.Hidden);
                
                // Faction name
                this.OneWayBind(ViewModel,
                    vm => vm.Mission.Faction,
                    view => view.FactionName.Text
                );
                
                // Mission name
                this.OneWayBind(ViewModel,
                    vm => vm.Mission.Title,
                    view => view.MissionName.Text);
                
                // Station name
                this.OneWayBind(ViewModel,
                    vm => vm.Mission.Station,
                    view => view.StationName.Text);
                
                // System name
                this.OneWayBind(ViewModel,
                    vm => vm.Mission.System,
                    view => view.SystemName.Text);
                
                // Reward
                this.OneWayBind(ViewModel,
                    vm => vm.Mission.Reward,
                    view => view.Reward.Text,
                    reward => $"{reward:C0}");
                
                // Progress
                this.OneWayBind(ViewModel,
                    vm => vm.Progress,
                    view => view.Progress.Text);

                // Expire text
                this.OneWayBind(ViewModel,
                    vm => vm.ExpiresIn,
                    view => view.Expiration.Text);
                
                // Docked highlighting
                this.OneWayBind(ViewModel,
                    vm => vm.IsDockedAtMissionStation,
                    view => view.Grid.Background,
                    isDocked => isDocked ? greenBrush : whiteBrush);
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
        public string Progress => $"{Mission.CurrentKills} / {Mission.TotalKills}";

        public MissionItemViewModel(Mission mission, StateTracker state)
        {
            var stationObservable = state.Station;
            Mission = mission;
            _isDockedAtMissionStation =
                stationObservable
                    .Select(station => Mission.CurrentKills >= Mission.TotalKills && station == Mission.Station)
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .ToProperty(this, x => x.IsDockedAtMissionStation);

            _expiresIn =
                Observable.Return(1L).Merge(
                Observable.Interval(TimeSpan.FromSeconds(10))
                )
                    .Select(_ =>
                    {
                        this.Mission.Expiry.Subtract(TimeSpan.Zero);
                        return mission.Expiry - DateTime.UtcNow;
                    })
                    .Select(time => $"Expires in: {time.Days}D {time.Hours}H {time.Minutes}M")
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .ToProperty(this, x => x.ExpiresIn);
        }
    }
}