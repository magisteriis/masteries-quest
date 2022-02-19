using RiotGames.LeagueOfLegends;

namespace MasteriesQuest.ViewModels;

public class SummonerViewModel : ObservableObject
{
    private string? _name;

    private long? _totalChampions;

    private long? _totalPoints;

    public SummonerViewModel()
    {
    }

    // Created just in-case.
    public SummonerViewModel(Summoner summoner)
    {
        Populate(summoner);
    }

    public SummonerViewModel(string name)
    {
        Name = name;
    }

    public Summoner? Summoner { get; private set; }

    public string? Name
    {
        get => _name;
        set => SetProperty(ref _name, value);
    }

    public long? TotalChampions
    {
        get => _totalChampions;
        set => SetProperty(ref _totalChampions, value);
    }

    public long? TotalPoints
    {
        get => _totalPoints;
        set => SetProperty(ref _totalPoints, value);
    }

    public ObservableCollection<ChampionMasteryViewModel> Masteries { get; } = new();

    public string? IntFormat(long? i, string format)
    {
        return i?.ToString(format);
    }

    public void Populate(Summoner summoner)
    {
        Summoner = summoner;
        Name = summoner.Name;
    }

    public void Populate(ICollection<ChampionMastery> masteries)
    {
        TotalChampions = masteries.LongCount();
        TotalPoints = masteries.Sum(m => (long) m.ChampionPoints);
        foreach (var mastery in masteries)
            Masteries.Add(new ChampionMasteryViewModel(mastery));
    }
}