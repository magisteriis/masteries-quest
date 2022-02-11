using CommunityToolkit.Mvvm.ComponentModel;
using RiotGames.LeagueOfLegends;
using System;
using System.Collections.Generic;
using System.Text;
using Humanizer;

namespace MasteriesQuest.ViewModels
{
    public class ChampionMasteryViewModel : ObservableObject
    {
        private ChampionMastery _mastery;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ChampionMasteryViewModel(ChampionMastery mastery) => Populate(mastery);
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

        private string _champion;

        public string Champion
        {
            get => _champion;
            set => SetProperty(ref _champion, value);
        }

        private byte _level;

        public byte Level
        {
            get => _level;
            set => SetProperty(ref _level, value);
        }

        private string _points;

        public string Points
        {
            get => _points;
            set => SetProperty(ref _points, value);
        }

        private bool? _isChestGranted;

        public bool? IsChestGranted
        {
            get => _isChestGranted;
            set => SetProperty(ref _isChestGranted, value);
        }

        private string _lastPlayed;

        public string LastPlayed
        {
            get => _lastPlayed;
            set => SetProperty(ref _lastPlayed, value);
        }

        public ChampionMastery Mastery => _mastery;
        
        public void Populate(ChampionMastery championMastery)
        {
            _mastery = championMastery;
            Champion = championMastery.ChampionId.ToChampion().ToString();
            Level = (byte)championMastery.ChampionLevel;
            Points = championMastery.ChampionPoints.ToString("N0");
            IsChestGranted = championMastery.ChestGranted;
            LastPlayed = TimeHelper.JavaTimeStampToDateTime(championMastery.LastPlayTime).Humanize();
        }
    }
}
