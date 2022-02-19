using Humanizer;
using RiotGames.LeagueOfLegends;

namespace MasteriesQuest.ViewModels;

public class ChampionMasteryViewModel : ObservableObject
{
    private string _champion;

    private bool? _isChestGranted;

    private string _lastPlayed;

    private byte _level;

    private string _points;

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
    public ChampionMasteryViewModel(ChampionMastery mastery)
    {
        Populate(mastery);
    }
#pragma warning restore CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.

    public string Champion
    {
        get => _champion;
        set => SetProperty(ref _champion, value);
    }

    public byte Level
    {
        get => _level;
        set => SetProperty(ref _level, value);
    }

    public string Points
    {
        get => _points;
        set => SetProperty(ref _points, value);
    }

    public bool? IsChestGranted
    {
        get => _isChestGranted;
        set => SetProperty(ref _isChestGranted, value);
    }

    public string LastPlayed
    {
        get => _lastPlayed;
        set => SetProperty(ref _lastPlayed, value);
    }

    public ChampionMastery Mastery { get; private set; }

    public void Populate(ChampionMastery championMastery)
    {
        Mastery = championMastery;
        Champion = championMastery.ChampionId.ToChampion().ToString();
        Level = (byte) championMastery.ChampionLevel;
        Points = championMastery.ChampionPoints.ToString("N0");
        IsChestGranted = championMastery.ChestGranted;
        LastPlayed = TimeHelper.JavaTimeStampToDateTime(championMastery.LastPlayTime).Humanize();
    }
}