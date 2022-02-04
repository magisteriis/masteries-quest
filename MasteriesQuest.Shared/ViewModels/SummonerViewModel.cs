using CommunityToolkit.Mvvm.ComponentModel;
using RiotGames.LeagueOfLegends;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace MasteriesQuest.ViewModels
{
    public class SummonerViewModel : ObservableObject
    {
        public string? IntFormat(long? i, string format) => i?.ToString(format);


        private string? _name;

        public SummonerViewModel() { }

        // Created just in-case.
        public SummonerViewModel(Summoner summoner) => Populate(summoner);

        public SummonerViewModel(string name) => Name = name;

        public Summoner? Summoner { get; private set; }

        public string? Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        private long? _totalChampions;

        public long? TotalChampions
        {
            get { return _totalChampions; }
            set => SetProperty(ref _totalChampions, value);
        }

        private long? _totalPoints;

        public long? TotalPoints
        {
            get { return _totalPoints; }
            set => SetProperty(ref _totalPoints, value);
        }

        public ObservableCollection<ChampionMasteryViewModel> Masteries { get; } = new();

        public void Populate(Summoner summoner)
        {
            Summoner = summoner;
            Name = summoner.Name;
        }

        public void Populate(ICollection<ChampionMastery> masteries)
        {
            TotalChampions = masteries.LongCount();
            TotalPoints = masteries.Sum(m => (long)m.ChampionPoints);
            foreach(var mastery in masteries)
                Masteries.Add(new ChampionMasteryViewModel(mastery));
        }
    }
}
