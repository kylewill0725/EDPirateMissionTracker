using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using System.Windows;
using Common;
using EliteAPI;
using EliteAPI.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using ReactiveUI;
using Splat;
using Splat.Microsoft.Extensions.DependencyInjection;
using Wpf.ViewModels;

namespace Wpf
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private IHost _host;
        public IServiceProvider Services => _host.Services;

        public App()
        {
            InitDependencyInjection();
            var view = _host.Services.GetService<IViewFor<MainWindowViewModel>>();
            view!.ViewModel = Services.GetService<MainWindowViewModel>();
            (view as Window)?.Show();
        }

        private void InitDependencyInjection()
        {
            var assembly = Assembly.GetCallingAssembly(); // Pulled out because calling inside configureservices results in the Hosting assembly
            _host =
                Host.CreateDefaultBuilder()
                    .ConfigureServices(services =>
                    {
                        services.UseMicrosoftDependencyResolver();
                        var resolver = Locator.CurrentMutable;
                        resolver.InitializeSplat();
                        resolver.InitializeReactiveUI();
                        resolver.RegisterViewsForViewModels(assembly);
                        
                        services.AddEliteAPI();
                        services.AddTransient<MissionCatchUp>();
                        services.AddTransient<IJournalReader, JournalReader>();
                        services.AddSingleton<MissionTargetManager>();
                        services.AddSingleton<MainWindowViewModel>();
                        services.AddSingleton<IScreen>(x => x.GetService<MainWindowViewModel>());
                        services.AddSingleton<CombatViewModel>();
                        services.AddSingleton<DockedViewModel>();
                        services.AddSingleton<StateTracker>();
                    })
                    .Build();
            Services.UseMicrosoftDependencyResolver();
        }
    }
}