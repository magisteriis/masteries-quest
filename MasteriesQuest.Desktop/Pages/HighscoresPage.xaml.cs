using ChampionMasteryGg;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Navigation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MasteriesQuest.Pages;

/// <summary>
///     An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class HighscoresPage : Page
{
    public HighscoresPage()
    {
        InitializeComponent();
    }

    public HighscoresOverviewViewModel HighscoresOverview { get; set; } = new();

    // TODO: Implement CancellationToken.
    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        _ = Task.Run(async () =>
        {
            try
            {
                using ChampionMasteryGgClient client = new();
                var highscores = await client.GetHighscoresAsync();
                DispatcherQueue.TryEnqueue(() =>
                {
                    //foreach (var highscore in highscores.TotalPoints)
                    //    HighscoresOverview.TotalPoints.Add(new HighscoreEntryViewModel(highscore));
                    //foreach (var highscore in highscores.TotalLevel)
                    //    HighscoresOverview.TotalLevel.Add(new HighscoreEntryViewModel(highscore));
                    foreach (var championHighscores in highscores.Champions)
                        HighscoresOverview.Champions.Add(new ChampionHighscoresViewModel(championHighscores));

                    Loading.IsLoading = false;
                });
            }
            catch (Exception ex)
            {
                LcuHelper.LastGameId = -1;
                DispatcherQueue.TryEnqueue(() =>
                {
                    Loading.IsLoading = false;
                    Error.Show(ex);
                });
            }
        });
    }
}