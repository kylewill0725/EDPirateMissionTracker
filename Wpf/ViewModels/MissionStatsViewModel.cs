using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using Common;
using DynamicData;
using DynamicData.Binding;
using DynamicData.PLinq;
using ReactiveUI;
using ReactiveUI.Fody.Helpers;

namespace Wpf.ViewModels
{
    public class MissionStatsViewModel : ReactiveObject, IRoutableViewModel
    {
        private readonly ReadOnlyObservableCollection<FactionGroup> _factions;
        public ReadOnlyObservableCollection<FactionGroup> Factions => _factions;
        public string UrlPathSegment => "combat";
        public IScreen HostScreen { get; }
        public int StackHeight { [ObservableAsProperty] get; }

        public MissionStatsViewModel(IScreen host, MissionTargetManager missionTargetManager)
        {
            HostScreen = host;

            missionTargetManager
                .Connect()
                .Select(m => m)
                .Group(m => m.Faction)
                .Filter(g => g.Cache.Count > 0)
                .Transform(g => new FactionGroup(g))
                .DisposeMany()
                .ObserveOn(RxApp.MainThreadScheduler)
                .Bind(out _factions)
                .Subscribe();

            var factionChanges =
                Factions.WhenAnyPropertyChanged();

            factionChanges
                .Select(x => x.Select(f => f.KillsRemaining).Append(0).Max())
                .ToPropertyEx(this, x => x.StackHeight);
            factionChanges
                .Select(x => x.Count(y => y.KillsRemaining > 0))
                .ToPropertyEx(this, x => x.StackWidth);
            factionChanges
                .Select(x => x.Select(y => y.MissionCount).Sum())
                .ToPropertyEx(this, x => x.MissionCount);
            factionChanges
                .Select(x => x.Select(y => y.KillsRemaining).Sum())
                .ToPropertyEx(this, x => x.TotalKills);
            this.WhenAnyValue(x => x.TotalKills, x => x.StackHeight,
                    (totalKills, stackHeight) => (totalKills, stackHeight))
                .Where(x => x.stackHeight > 0)
                .Select(x => (double) x.totalKills / x.stackHeight)
                .ToPropertyEx(this, x => x.Ratio);
            factionChanges
                .Select(x => x.Select(y => y.RewardTotal).Sum())
                .ToPropertyEx(this, x => x.TotalPayout);
            this.WhenAnyValue(x => x.MissionCount, x => x.TotalPayout,
                    (missionCount, totalPayout) => (totalPayout, missionCount))
                .Where(x => x.missionCount > 0)
                .Select(x => (double) x.totalPayout / x.missionCount)
                .ToPropertyEx(this, x => x.MissionAverageReward);

            factionChanges
                .Select(x =>
                    x.Where(y => y.Mission1TotalKills > 0)
                        .Select(y => (double) y.Mission1Reward / y.Mission1TotalKills).Sum())
                .ToPropertyEx(this, x => x.MillPerKill);
        }

        public double MillPerKill { [ObservableAsProperty] get; }

        public double MissionAverageReward { [ObservableAsProperty] get; }

        public long TotalPayout { [ObservableAsProperty] get; }

        public double Ratio { [ObservableAsProperty] get; }

        public int TotalKills { [ObservableAsProperty] get; }

        public int MissionCount { [ObservableAsProperty] get; }

        public int StackWidth { [ObservableAsProperty] get; }
    }

    public class FactionGroup : ReactiveObject, IDisposable
    {
        private IDisposable _cleanup;
        private readonly ReadOnlyObservableCollection<KillValuePair> _missionKillsRemaining;

        public FactionGroup(IGroup<Mission, string, string> group)
        {
            Name = group.Key;
            var comparer = SortExpressionComparer<Mission>.Ascending(m => m.MissionId);
            var killCountRemaining =
                group.Cache.Connect()
                    .Where(x => x.Count > 0)
                    .Sort(comparer)
                    .Transform(
                        m => new KillValuePair(m.TotalKills - m.CurrentKills, m.TotalKills, m.Reward, m.IsFilled))
                    .ObserveOn(RxApp.MainThreadScheduler)
                    .Bind(out _missionKillsRemaining)
                    .Subscribe();

            var kcChanges = 
                _missionKillsRemaining
                .WhenAnyPropertyChanged()
                .Prepend(_missionKillsRemaining); // Send initial state
            kcChanges
                .Select(x => x.Count)
                .ToPropertyEx(this, x => x.MissionCount);
            kcChanges
                .Select(x => x.Sum(i => i.Total))
                .ToPropertyEx(this, x => x.KillsTotal);
            kcChanges
                .Select(x => x.Sum(i => Math.Max(i.Remaining, 0)))
                .ToPropertyEx(this, x => x.KillsRemaining);
            kcChanges
                .Select(x => x.FirstOrDefault(y => !y.IsFilled)?.Remaining ?? 0)
                .ToPropertyEx(this, x => x.Mission1Remaining);
            kcChanges
                .Select(x => x.FirstOrDefault(y => !y.IsFilled)?.Reward ?? 0)
                .ToPropertyEx(this, x => x.Mission1Reward);
            kcChanges
                .Select(x => x.FirstOrDefault(y => !y.IsFilled)?.Total ?? 0)
                .ToPropertyEx(this, x => x.Mission1TotalKills);
            kcChanges
                .Select(x => x.Where(y => !y.IsFilled).Skip(1).FirstOrDefault()?.Remaining ?? 0)
                .ToPropertyEx(this, x => x.Mission2Remaining);
            kcChanges
                .Select(x => x.Where(y => !y.IsFilled).Skip(2).FirstOrDefault()?.Remaining ?? 0)
                .ToPropertyEx(this, x => x.Mission3Remaining);
            kcChanges
                .Select(x => x.Where(y => !y.IsFilled).Skip(3).FirstOrDefault()?.Remaining ?? 0)
                .ToPropertyEx(this, x => x.Mission4Remaining);
            kcChanges
                .Select(x => x.Sum(i => i.Reward))
                .ToPropertyEx(this, x => x.RewardTotal);
            _cleanup = new CompositeDisposable(killCountRemaining);
        }

        public int Mission4Remaining { [ObservableAsProperty] get; }

        public string Name { get; }
        public long Mission1Reward { [ObservableAsProperty] get; }
        public int Mission1Remaining { [ObservableAsProperty] get; }
        public int Mission1TotalKills { [ObservableAsProperty] get; }
        public int Mission2Remaining { [ObservableAsProperty] get; }
        public int Mission3Remaining { [ObservableAsProperty] get; }
        public int KillsRemaining { [ObservableAsProperty] get; }
        public int MissionCount { [ObservableAsProperty] get; }
        public int KillsTotal { [ObservableAsProperty] get; }
        public long RewardTotal { [ObservableAsProperty] get; }

        public void Dispose()
        {
            _cleanup?.Dispose();
        }
    }

    public record KillValuePair(int Remaining, int Total, long Reward, bool IsFilled);
}