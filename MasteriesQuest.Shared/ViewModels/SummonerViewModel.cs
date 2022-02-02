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
        private string _name;

        public string Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public ObservableCollection<ChampionMastery> Masteries { get; } = new();

        public void Populate(Summoner summoner)
        {
            Name = summoner.Name;
        }

        public void Populate(ICollection<ChampionMastery> masteries)
        {
            foreach(var mastery in masteries)
                Masteries.Add(mastery);
        }
    }
}
