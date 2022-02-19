using Microsoft.AspNetCore.Components;
using RiotGames.LeagueOfLegends;

namespace MasteriesQuest;

public static class NavigationManagerExtensions
{
    public static void NavigateTo(this NavigationManager navManager, Server server, bool replace = false)
    {
        navManager.NavigateTo($"{server.Abbreviation.ToLower()}", replace: replace);
    }

    public static void NavigateTo(this NavigationManager navManager, Server server, Summoner summoner,
        bool replace = false)
    {
        navManager.NavigateTo($"{server.Abbreviation.ToLower()}/{Uri.EscapeDataString(summoner.Name)}",
            replace: replace);
    }

    public static void NavigateTo(this NavigationManager navManager, Server server, Match match, bool replace = false)
    {
        navManager.NavigateTo($"{server.Abbreviation.ToLower()}/matches/{match.Info.GameId}", replace: replace);
    }

    public static void NavigateTo(this NavigationManager navManager, Server server, SpectatorCurrentGameInfo activeGame,
        Summoner summoner, bool replace = false)
    {
        navManager.NavigateTo(
            $"{server.Abbreviation.ToLower()}/matches/{activeGame.GameId}/{string.Join(",", activeGame.Participants.GroupBy(p => p.TeamId).Single(g => g.Any(p => p.SummonerName == summoner.Name)).Select(s => Uri.EscapeDataString(s.SummonerName)))}",
            replace: replace);
    }
}