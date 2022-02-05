using System;
using System.Collections.Generic;
using System.Text;
using ChampionMasteryGg;
using RiotGames.LeagueOfLegends;

namespace MasteriesQuest.ViewModels
{
    public class HighscoresOverviewViewModel : ObservableObject
    {
        public ObservableCollection<HighscoreEntryViewModel> TotalPoints { get; } = new();
        public ObservableCollection<HighscoreEntryViewModel> TotalLevel { get; } = new();
        public ObservableCollection<ChampionHighscoresViewModel> Champions { get; } = new();
    }

    public class ChampionHighscoresViewModel : ObservableObject
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public ChampionHighscoresViewModel(Camille.Enums.Champion champion)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            ChampionId = (int) champion;
            ChampionName = champion.ToString();
        }

        public ChampionHighscoresViewModel(int championId) : this((Camille.Enums.Champion)championId)
        {
        }

        public ChampionHighscoresViewModel(KeyValuePair<Champion, PointsHighscoresCollection> championHighscores) : this(championHighscores.Key.Id)
        {
            foreach(var highscore in championHighscores.Value)
                Highscores.Add(new HighscoreEntryViewModel(highscore));
        }

        private int _championId;

        public int ChampionId
        {
            get => _championId;
            set => SetProperty(ref _championId, value);
        }

        private string _championName;

        public string ChampionName
        {
            get => _championName;
            set => SetProperty(ref _championName, value);
        }

        public List<HighscoreEntryViewModel> Highscores { get; } = new();
    }

    public class HighscoreEntryViewModel : ObservableObject
    {
#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public HighscoreEntryViewModel(string summonerName, Server server)
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        {
            SummonerName = summonerName;
            Server = server;
        }

        public HighscoreEntryViewModel(string summonerName, string server) : this(summonerName, Server.Parse(server))
        {
        }

        public HighscoreEntryViewModel(ChampionMasteryGg.Summoner summoner) : this(summoner.Name, summoner.Region)
        {
        }

        public HighscoreEntryViewModel(IHighscore highscore) : this(highscore.Summoner)
        {
            Score = highscore.Score;
        }

        private Server _server;

        public Server Server
        {
            get => _server;
            set => SetProperty(ref _server, value);
        }

        private string _summonerName;

        public string SummonerName
        {
            get => _summonerName;
            set => SetProperty(ref _summonerName, value);
        }

        private long? _score;

        public long? Score
        {
            get => _score;
            set => SetProperty(ref _score, value);
        }
    }
}
