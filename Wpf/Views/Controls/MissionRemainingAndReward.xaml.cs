using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using Wpf.ViewModels;

namespace Wpf.Views.Controls
{
    public partial class MissionRemainingAndReward : UserControl, INotifyPropertyChanged
    {
        public enum MissionIndexes
        {
            One = 1,
            Two,
            Three,
            Four
        }
        
        public static readonly DependencyProperty MissionProperty =
            DependencyProperty.Register(nameof(Mission), typeof(FactionGroup), typeof(MissionRemainingAndReward), new PropertyMetadata(MissionChangedCallback));

        private static void MissionChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MissionRemainingAndReward) d).UpdateData();
        }

        public FactionGroup Mission
        {
            get => (FactionGroup) GetValue(MissionProperty);
            set
            {
                SetValue(MissionProperty, value);
                UpdateData();
            }
        }

        public static readonly DependencyProperty MissionIndexProperty =
            DependencyProperty.Register(nameof(MissionIndex), typeof(MissionIndexes), typeof(MissionRemainingAndReward), new PropertyMetadata(MissionIndexChangedCallback));

        private static void MissionIndexChangedCallback(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            ((MissionRemainingAndReward) d).UpdateData();
        }

        private int _remaining;
        private int _reward;

        public MissionIndexes MissionIndex
        {
            get => (MissionIndexes) GetValue(MissionIndexProperty);
            set
            {
                SetValue(MissionIndexProperty, value);
                UpdateData();
            }
        }

        public int Remaining
        {
            get => _remaining;
            set
            {
                _remaining = value;
                OnPropertyChanged();
            }
        }

        public int Reward
        {
            get => _reward;
            set
            {
                _reward = value;
                OnPropertyChanged();
            }
        }

        public MissionRemainingAndReward()
        {
            InitializeComponent();
        }

        private void UpdateData()
        {
            if (Mission == null || (int) MissionIndex < 1) return;
            
            Remaining = MissionIndex switch
            {
                MissionIndexes.One => Mission.Mission1Remaining,
                MissionIndexes.Two => Mission.Mission2Remaining,
                MissionIndexes.Three => Mission.Mission3Remaining,
                MissionIndexes.Four => Mission.Mission4Remaining,
                _ => 0
            };
            Reward = MissionIndex switch
            {
                MissionIndexes.One => (int) (Mission.Mission1Reward / 1_000_000),
                MissionIndexes.Two => (int) (Mission.Mission2Reward / 1_000_000),
                MissionIndexes.Three => (int) (Mission.Mission3Reward / 1_000_000),
                MissionIndexes.Four => (int) (Mission.Mission4Reward / 1_000_000),
                _ => 0
            };
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}