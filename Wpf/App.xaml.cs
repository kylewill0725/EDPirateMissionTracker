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
            var api = Services.GetService<MainWindow>();
        }

        private void InitDependencyInjection()
        {
            _host =
                Host.CreateDefaultBuilder()
                    .ConfigureServices(services =>
                    {
                        services.UseMicrosoftDependencyResolver();
                        var resolver = Locator.CurrentMutable;
                        resolver.InitializeSplat();
                        resolver.InitializeReactiveUI();
                        resolver.RegisterViewsForViewModels(Assembly.GetCallingAssembly());
                        
                        services.AddEliteAPI(listener =>
                        {
                            listener.AddEventModule<MissionTargetManager>();
                        });
                        services.AddTransient<BountyCatchUp>();
                        services.AddTransient<IJournalReader, JournalReader>();
                        services.AddSingleton<MissionTargetManager>();
                    })
                    .Build();
            Services.UseMicrosoftDependencyResolver();
        }
    }
}