
using System;
using System.ComponentModel;
using System.Globalization;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using System.Windows.Data;
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

                // ViewModel.WhenAnyValue(x => x.Factions)
                //     .Take(1)
                //     .Subscribe(_ =>
                //     {
                //         var columnBinding = KillTotalColumn.DisplayMemberBinding as Binding;
                //         var sortBy = columnBinding?.Path.Path ?? KillTotalColumn.Header as string;
                //         Sort(sortBy, ListSortDirection.Ascending);
                //     }).DisposeWith(disposable);

                // ViewModel.WhenAnyValue(x => x.Factions)
                //     .Subscribe(_ => SimpleSort()).DisposeWith(disposable);

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
                    vm => vm.MissionsDone,
                    view => view.MissionsDone.Data
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

        private void Sort(string sortBy, ListSortDirection direction)
        {
            ICollectionView dataView =
              CollectionViewSource.GetDefaultView(FactionList.ItemsSource);

            dataView.SortDescriptions.Clear();
            SortDescription sd = new SortDescription(sortBy, direction);
            dataView.SortDescriptions.Add(sd);
            dataView.Refresh();
        }

        private void SimpleSort()
        {
            ICollectionView dataView =
                CollectionViewSource.GetDefaultView(FactionList.ItemsSource);
            dataView.Refresh();
        }
    }

    public class MissionRewardConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (long) value / 1_000_000;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}