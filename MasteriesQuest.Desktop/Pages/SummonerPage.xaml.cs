using MasteriesQuest.ViewModels;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using RiotGames.LeagueOfLegends;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MasteriesQuest.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class SummonerPage : Page
    {
        public SummonerPage()
        {
            this.InitializeComponent();
        }

        public SummonerViewModel Summoner { get; set; } = new SummonerViewModel();

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            var summonerName = e.Parameter as string;
            _ = Task.Run(async () =>
            {
                try
                {
                    // Needs region as parameter.
                    using LeagueOfLegendsClient client = new("desktop", Server.EUW);

                    var summoner = await client.GetSummonerByNameAsync(summonerName);

                    if (summoner != null)
                    {
                        DispatcherQueue.TryEnqueue(() =>
                        {
                            Summoner.Populate(summoner);
                        });

                        var masteries = await client.GetChampionMasteriesAsync(summoner.Id);

                        DispatcherQueue.TryEnqueue(() =>
                        {
                            Summoner.Populate(masteries);
                            SummonerGrid.Visibility = Visibility.Visible;
                            LoadingControl.IsLoading = false;
                        });
                    }
                }
                catch (HttpRequestException ex)
                {
                    DispatcherQueue.TryEnqueue(() =>
                    {
                        LoadingControl.IsLoading = false;
                        Error.Reason = ex.Message.Contains("429") ? Controls.ErrorReason.RateLimit : Controls.ErrorReason.NotFound;
                        Error.Show();
                    });
                }
                catch (Exception)
                {
                    DispatcherQueue.TryEnqueue(() =>
                    {
                        LoadingControl.IsLoading = false;
                        Error.Reason = Controls.ErrorReason.Error;
                        Error.Show();
                    });
                }
            });
        }
    }
}
