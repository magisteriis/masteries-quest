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

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            try
            {
                var summonerName = e.Parameter as string;

                using LeagueOfLegendsClient client = new("desktop", Server.EUW);
                var summoner = await client.GetSummonerByNameAsync(summonerName);

                DispatcherQueue.TryEnqueue(() =>
                {
                    SummonerGrid.Visibility = Visibility.Visible;
                    Summoner.Populate(summoner);
                });

                var masteries = await client.GetChampionMasteriesAsync(summoner.Id);
                DispatcherQueue.TryEnqueue(() =>
                {
                    Summoner.Populate(masteries);
                    LoadingControl.IsLoading = false;
                });
            }
            catch (HttpRequestException ex)
            {
                LoadingControl.IsLoading = false;
                SummonerNotFoundError.Visibility = Visibility.Visible;
            }
            catch (Exception ex)
            {
                LoadingControl.IsLoading = false;
                SummonerNotFoundError.Visibility = Visibility.Visible;
            }
        }
    }
}
