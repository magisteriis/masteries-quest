using System.Collections;
using RiotGames.LeagueOfLegends;

namespace MasteriesQuest.ViewModels;

public partial class FeaturedGamesViewModel : ObservableObject
{
    private CancellationTokenSource _loadCancellationTokenSource = new();

    public ObservableCollection<MatchViewModel> FeaturedGames { get; set; } = new();

    public void CancelLoad()
    {
        _loadCancellationTokenSource.Cancel();
    }
}

public class MatchViewModel : ObservableObject, IEnumerable<TeamViewModel>
{
    private SpectatorFeaturedGameInfo _game;
    private Server? _server;

    public MatchViewModel(SpectatorFeaturedGameInfo game)
    {
        _game = game;
        Server = Server.Parse(game.PlatformId);
        var teams = game.Participants.GroupBy(p => p.TeamId);
        foreach (var team in teams)
            Teams.Add(new TeamViewModel(team));
    }

    public Server? Server
    {
        get => _server;
        set => SetProperty(ref _server, value);
    }

    public ObservableCollection<TeamViewModel> Teams { get; set; } = new();

    public IEnumerator<TeamViewModel> GetEnumerator()
    {
        return ((IEnumerable<TeamViewModel>) Teams).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable) Teams).GetEnumerator();
    }
}

public class TeamViewModel : ObservableObject, IEnumerable<ParticipantViewModel>
{
    private IGrouping<long, SpectatorParticipant> _team;

    public TeamViewModel(IGrouping<long, SpectatorParticipant> team)
    {
        _team = team;
        TeamId = team.Key;
        foreach (var participant in team)
            Participants.Add(new ParticipantViewModel(participant));
    }

    public long? TeamId { get; set; }

    public ObservableCollection<ParticipantViewModel> Participants { get; set; } = new();

    public IEnumerator<ParticipantViewModel> GetEnumerator()
    {
        return ((IEnumerable<ParticipantViewModel>) Participants).GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable) Participants).GetEnumerator();
    }
}

public class ParticipantViewModel : SummonerViewModel
{
    private long? _championId;
    private long? _championPoints;

    public ParticipantViewModel(string name) : base(name)
    {
    }

    public ParticipantViewModel(SpectatorParticipant spectatorParticipant) : base(spectatorParticipant.SummonerName)
    {
        ChampionId = spectatorParticipant.ChampionId;
    }

    public long? ChampionId
    {
        get => _championId;
        set => SetProperty(ref _championId, value);
    }

    public long? ChampionPoints
    {
        get => _championPoints;
        set => SetProperty(ref _championPoints, value);
    }

    public void Populate(ChampionMastery championMastery)
    {
        ChampionPoints = championMastery.ChampionPoints;
    }
}