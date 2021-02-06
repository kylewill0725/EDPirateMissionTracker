using ReactiveUI;

namespace Wpf.ViewModels
{
    public class DockedViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment { get; } = "Docked";
        public IScreen HostScreen { get; }

        public DockedViewModel(IScreen hostScreen)
        {
            HostScreen = hostScreen;
        }
    }
}