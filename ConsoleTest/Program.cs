using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Common;
using EliteAPI;
using EliteAPI.Abstractions;
using EliteAPI.Event.Models;
using EliteAPI.Journal.Directory.Abstractions;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json.Linq;

namespace ConsoleTest
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var host =
                Host.CreateDefaultBuilder()
                    .ConfigureServices(services =>
                    {
                        services.AddEliteAPI();
                        services.AddTransient<MissionCatchUp>();
                        services.AddSingleton<JournalReader>();
                        services.AddSingleton<IJournalReader, JournalReader>(services => services.GetService<JournalReader>()!);
                        services.AddSingleton<MissionTargetManager>();
                    })
                    .Build();
            var api = host.Services.GetService<IEliteDangerousApi>();
            // host.Services.GetService<JournalReader>()!.EventFile = "testExample.txt";
            host.Services.GetService<MissionCatchUp>()!.CatchUp();
            var targetManager = host.Services.GetService<MissionTargetManager>()!;
            // await api.StartAsync();

            Debugger.Break();
            while (true)
                await Task.Delay(500);
        }
    }


    internal record Test(long Last, List<long> Diffs);
}