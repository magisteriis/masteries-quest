using RiotGames.LeagueOfLegends;
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
}
