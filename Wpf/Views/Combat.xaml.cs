
using System.Reactive.Disposables;
using ReactiveUI;

namespace Wpf.Views
{
    public partial class Combat
    {
        public Combat()
        {
            InitializeComponent();

            this.WhenActivated(disposable =>
            {
                this.OneWayBind(ViewModel,
                    vm => vm.Factions,
                    view => view.FactionList.ItemsSource
                ).DisposeWith(disposable);

                this.OneWayBind(ViewModel,
                    vm => vm.StackHeight,
                    view => view.StackHeight.Data
                ).DisposeWith(disposable);

                this.OneWayBind(ViewModel,
                    vm => vm.StackWidth,
                    view => view.StackWidth.Data
                ).DisposeWith(disposable);

                this.OneWayBind(ViewModel,
                    vm => vm.MissionCount,
                    view => view.MissionCount.Data
                ).DisposeWith(disposable);

                this.OneWayBind(ViewModel,
                    vm => vm.TotalKills,
                    view => view.TotalKills.Data
                ).DisposeWith(disposable);

                this.OneWayBind(ViewModel,
                    vm => vm.Ratio,
                    view => view.Ratio.Data,
                    i => $"{i:F2}"
                ).DisposeWith(disposable);

                this.OneWayBind(ViewModel,
                    vm => vm.TotalPayout,
                    view => view.TotalPayout.Data,
                    i => $"{i / 1_000_000.0:C} mil"
                ).DisposeWith(disposable);

                this.OneWayBind(ViewModel,
                    vm => vm.MissionAverageReward,
                    view => view.MissionAverage.Data,
                    i => $"{i/1_000_000:C} mil"
                ).DisposeWith(disposable);

                this.OneWayBind(ViewModel,
                    vm => vm.MillPerKill,
                    view => view.MillPerKill.Data,
                    i => $"{i/1_000_000:C} mil"
                ).DisposeWith(disposable);

            });
        }
    }
}