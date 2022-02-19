using RiotGames.LeagueOfLegends.LeagueClient;

namespace MasteriesQuest;

public static class LcuHelper
{
    /// <summary>
    ///     So we don't pull the data if we don't need it.
    /// </summary>
    public static long? LastGameId;

    /// <summary>
    ///     1 for blue, 2 for red.
    /// </summary>
    public static int TeamId { get; set; }

    public static async Task<string[]?> GetChampSelectSummonerNames()
    {
        try
        {
            using LeagueClient.LeagueOfLegendsClient client = new();
            var session = await client.ChampSelect.GetSessionAsync();
            // If we've already pulled data for this game then we don't need it again.
            if (session.GameId == LastGameId) return null;
            if (session.GameId != 0) LastGameId = session.GameId;
            TeamId = session.MyTeam[0].Team;
            var summoners = await client.Summoner.GetSummonersAsync(session.MyTeam);
            return summoners.Select(s => s.DisplayName).ToArray();
        }
        catch (Exception)
        {
            // For now, do nothing if anything fails.
            return null;
        }
    }
}