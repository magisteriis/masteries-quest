using ChampionMasteryGg;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
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
    public sealed partial class HighscoresPage : Page
    {
        public HighscoresPage()
        {
            this.InitializeComponent();
        }

        public HighscoresOverviewViewModel HighscoresOverview { get; set; } = new();

        // TODO: Implement CancellationToken.
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _ = Task.Run(async () =>
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
                });
            });
        }
    }
}
