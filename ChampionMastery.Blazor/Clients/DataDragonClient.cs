using System.Net.Http.Json;

namespace ChampionMastery.Clients
{
    public sealed class DataDragonClient : IDisposable
    {
        private HttpClient _httpClient;

        public DataDragonClient()
        {
            _httpClient = new HttpClient();
        }

        //public async Task<Champion[]?> GetChampionsAsync()
        //{
        //    var result = await _httpClient.GetFromJsonAsync<ChampionResult>("http://ddragon.leagueoflegends.com/cdn/12.2.1/data/en_US/champion.json");
        //    return result?.Data?.Values?.ToArray();
        //}

        public void Dispose() => _httpClient.Dispose();

        //private class ChampionResult
        //{
        //    public Dictionary<string, Champion>? Data { get; set; }
        //}
    }
}
