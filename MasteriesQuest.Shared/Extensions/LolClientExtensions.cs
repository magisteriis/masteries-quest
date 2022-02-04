using RiotGames;
using RiotGames.LeagueOfLegends;
using RiotGames.LeagueOfLegends.LeagueClient;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;

namespace MasteriesQuest
{
    public static class LolClientExtensions
    {
        /// <summary>
        /// Until it's been implemented upstream (auto-prefixing). 
        /// </summary>
        public static async Task<Match> GetMatchAsync(this LeagueOfLegendsClient client, [NotNull] Server server, [NotNull] long matchId) =>
            await client.GetMatchAsync($"{server.Platform}_{matchId}");

        /// <summary>
        /// Until IEncryptedSummonerId has been fixed upstream.
        /// </summary>
        public static async Task<SpectatorCurrentGameInfo> GetSpectatorActiveGameAsync(this LeagueOfLegendsClient client, Summoner summoner) =>
            await client.GetSpectatorActiveGameAsync(summoner.Id);
    }

    public static class LcuExtensions
    {
        internal static async Task<LolSummonerSummoner> GetSummonerAsync(this LeagueClient.LeagueOfLegendsClient.SummonerClient client, ISummonerId summoner) =>
            await client.GetSummonerAsync(summoner.SummonerId);

        internal static async Task<LolSummonerSummoner[]> GetSummonersAsync(this LeagueClient.LeagueOfLegendsClient.SummonerClient client, IEnumerable<ISummonerId> summoners)
        {
            List<LolSummonerSummoner> summs = new();
            foreach (var summoner in summoners)
                summs.Add(await client.GetSummonerAsync(summoner));
            return summs.ToArray();
        }
    }
}
