using Camille.Enums;
using RiotGames.LeagueOfLegends;

namespace MasteriesQuest.ViewModels;

public class SummonerSearchViewModel : ObservableObject
{
    private string? _summonerName;
    private Server _server = Server.NA; // TODO: Select based on user country.

    [Required]
    public string? SummonerName
    {
        get => _summonerName;
        set => SetProperty(ref _summonerName, value);
    }

#if WINDOWS
        public Server Server { get => _server; set => SetProperty(ref _server, value); }
#else
    [Required]
    public PlatformRoute Platform
    {
        get => _server;
        set => SetProperty(ref _server, value);
    }
#endif
    public List<Server> Servers { get; set; } = Server.All.Where(x => x != Server.PBE).ToList();
}