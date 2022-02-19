using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MasteriesQuest.Pages;

/// <summary>
///     An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class SummonerPage : Page
{
    public SummonerPage()
    {
        InitializeComponent();
    }

    public SummonerViewModel Summoner { get; set; } = new();

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
                    DispatcherQueue.TryEnqueue(() => { Summoner.Populate(summoner); });

                    var masteries = await client.GetChampionMasteriesAsync(summoner.Id);

                    DispatcherQueue.TryEnqueue(() =>
                    {
                        Summoner.Populate(masteries);
                        SummonerGrid.Visibility = Visibility.Visible;
                        Loading.IsLoading = false;
                    });
                }
            }
            catch (Exception ex)
            {
                DispatcherQueue.TryEnqueue(() =>
                {
                    Loading.IsLoading = false;
                    Error.Show(ex);
                });
            }
        });
    }
}