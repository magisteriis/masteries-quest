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
    public sealed partial class HomePage : Page
    {
        public HomePage()
        {
            this.InitializeComponent();
        }

        private void SummonerSearchBox_OnSearchClicked(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(SummonerSearchBox.SummonerSearch.SummonerName)) return;
            App.Window.Navigate(typeof(SummonerPage), SummonerSearchBox.SummonerSearch.SummonerName);
            SummonerSearchBox.SummonerSearch.SummonerName = null;
        }
    }
}
