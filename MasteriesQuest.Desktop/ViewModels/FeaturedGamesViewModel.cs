using Microsoft.UI.Dispatching;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MasteriesQuest.ViewModels
{
    public partial class FeaturedGamesViewModel
    {
        public async Task LoadAsync(DispatcherQueue dispatcherQueue, Server server)
        {
            if (_loadCancellationTokenSource.IsCancellationRequested)
                _loadCancellationTokenSource = new CancellationTokenSource();

            SpectatorFeaturedGames featuredGames;
            using (var client = new LeagueOfLegendsClient("github", server))
            {
                featuredGames = await client.GetSpectatorFeaturedGamesAsync(_loadCancellationTokenSource.Token);
                dispatcherQueue.TryEnqueue(() =>
                {
                    foreach (var game in featuredGames.GameList)
                        FeaturedGames.Add(new MatchViewModel(game));
                });
            }

            try
            {
                foreach (var serverGames in FeaturedGames.GroupBy(g => g.Server)) // While on dev token
                {
                    _loadCancellationTokenSource.Token.ThrowIfCancellationRequested();
                    using var client = new LeagueOfLegendsClient("github", serverGames.Key);
                    foreach (var participant in serverGames.SelectMany(sg => sg).SelectMany(g => g))
                    {
                        var summoner = await client.GetSummonerByNameAsync(participant.Name, _loadCancellationTokenSource.Token);
                        var masteries = await client.GetChampionMasteryAsync((long)participant.ChampionId, summoner.Id, _loadCancellationTokenSource.Token);

                        dispatcherQueue.TryEnqueue(() => participant.Populate(masteries));

                        await Task.Delay(500, _loadCancellationTokenSource.Token); // While on dev token
                    }
                }
            }
            catch { }
        }
    }
}
