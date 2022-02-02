using Blazored.LocalStorage;
using Camille.Enums;
using RiotGames.LeagueOfLegends;

namespace MasteriesQuest
{
    public static class LocalStorageExtensions
    {
        public static async Task SetSummonerAsync(this ILocalStorageService localStorage, PlatformRoute region, Summoner summoner) => 
            await localStorage.SetItemAsync(_summonerKey(region, summoner.Name), summoner);

        public static async Task<Summoner?> GetSummonerAsync(this ILocalStorageService localStorage, PlatformRoute route, string name) =>
            await localStorage.GetItemAsync<Summoner>(_summonerKey(route, name));

        private static string _summonerKey(PlatformRoute region, string name) =>
            $"{region}/{name.RemoveChars(' ').ToLower()}";
    }
}
