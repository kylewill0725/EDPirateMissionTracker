using System.Windows.Controls;
using ReactiveUI;

namespace Wpf.Views
{
    public partial class Docked
    {
        public Docked()
        {
            InitializeComponent();
            this.WhenActivated(disposables =>
            {
                this.OneWayBind(ViewModel,
                    vm => vm.Missions,
                    view => view.Missions.ItemsSource);
            });
        }
    }
}