using MasteriesQuest.Pages;
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

namespace MasteriesQuest
{
    /// <summary>
    /// An empty window that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();
            this.Title = "The Masteries Quest";
            this.ExtendsContentIntoTitleBar = true;
            this.SetTitleBar(AppTitleBar);
            this.Activated += async (_, e) =>
            {
                if (e.WindowActivationState != WindowActivationState.Deactivated)
                    await _readSummonersFromLcuAsync();
            };
        }

        private void MainNavigationView_SelectionChanged(NavigationView sender, NavigationViewSelectionChangedEventArgs args)
        {
            if (args.IsSettingsSelected)
            {
                contentFrame.Navigate(typeof(SettingsPage));
            }
            else
            {
                var selectedItem = (NavigationViewItem)args.SelectedItem;
                if (selectedItem != null)
                {
                    string selectedItemTag = ((string)selectedItem.Tag);
                    string pageName = "MasteriesQuest.Pages." + selectedItemTag;
                    Type pageType = Type.GetType(pageName);
                    contentFrame.Navigate(pageType);
                }
            }
        }

        private void AutoSuggestBox_TextChanged(AutoSuggestBox sender, AutoSuggestBoxTextChangedEventArgs args)
        {
            // TODO: Suggest past summoner and maybe lookup the current text to correct capitalization etc.
        }

        private void AutoSuggestBox_QuerySubmitted(AutoSuggestBox sender, AutoSuggestBoxQuerySubmittedEventArgs args)
        {
            contentFrame.Navigate(typeof(SummonerPage), args.QueryText);
            AutoSuggestBoxControl.Text = null;
            contentFrame.Focus(FocusState.Programmatic);
        }

        private async Task _readSummonersFromLcuAsync()
        {
            try
            {
                var summonerNames = await LcuHelper.GetChampSelectSummonerNames().TimeoutAfter(TimeSpan.FromSeconds(3));

                // If no summoners found, do nothing.
                if (summonerNames == null || summonerNames.Length == 0)
                    return;

                contentFrame.Navigate(typeof(ChampSelectPage), summonerNames);
            }
            // Thrown by TimeoutAfter.
            catch (TimeoutException)
            {
                return;
            }
        }
    }
}
