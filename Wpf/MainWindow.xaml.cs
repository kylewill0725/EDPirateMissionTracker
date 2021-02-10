using System.Diagnostics;
using System.Reactive.Disposables;
using System.Windows;
using System.Windows.Input;
using ReactiveUI;
using Wpf.ViewModels;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            this.WhenActivated(disposables =>
            {
                this.OneWayBind(ViewModel, x => x.Router, x => x.RoutedViewHost.Router)
                    .DisposeWith(disposables);
                this.OneWayBind(ViewModel, 
                    vm => vm.DoneLoading, 
                    view => view.Loading.Visibility,
                    doneLoading => !doneLoading ? Visibility.Visible : Visibility.Collapsed)
                    .DisposeWith(disposables);
                this.OneWayBind(ViewModel,
                    vm => vm.DoneLoading,
                    view => view.RoutedViewHost.Visibility,
                    doneLoading => doneLoading ? Visibility.Visible : Visibility.Collapsed)
                    .DisposeWith(disposables);
            });
        }

        private void UIElement_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            Debug.WriteLine("Clicked");
        }
    }
}