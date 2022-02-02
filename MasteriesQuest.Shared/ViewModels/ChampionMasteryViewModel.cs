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
        public ChampionMasteryViewModel(ChampionMastery mastery)
        {
            Populate(mastery);
        }

        private string _champion;

        public string Champion
        {
            get { return _champion; }
            set => SetProperty(ref _champion, value);
        }

        private byte _level;

        public byte Level
        {
            get { return _level; }
            set => SetProperty(ref _level, value);
        }

        private string _points;

        public string Points
        {
            get { return _points; }
            set => SetProperty(ref _points, value);
        }

        private bool _isChestGranted;

        public bool IsChestGranted
        {
            get { return _isChestGranted; }
            set => SetProperty(ref _isChestGranted, value);
        }

        private string _lastPlayed;



        public string LastPlayed
        {
            get { return _lastPlayed; }
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
