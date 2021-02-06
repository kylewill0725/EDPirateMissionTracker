using ReactiveUI;

namespace Wpf.ViewModels
{
    public class CombatViewModel : ReactiveObject, IRoutableViewModel
    {
        public string UrlPathSegment => "combat";
        public IScreen HostScreen { get; }

        public CombatViewModel(IScreen host)
        {
            HostScreen = host;
        }
    }
}