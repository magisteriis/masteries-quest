using MasteriesQuest.Pages;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MasteriesQuest;

/// <summary>
///     An empty window that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
        Title = "The Masteries Quest";
        ExtendsContentIntoTitleBar = true;
        SetTitleBar(AppTitleBar);
        this.SetWindowIcon("Assets/Square44x44Logo.ico"); // For task switcher
        Activated += async (_, e) =>
        {
            if (e.WindowActivationState != WindowActivationState.Deactivated)
                await _readSummonersFromLcuAsync();
        };
    }

    private void MainNavigationView_SelectionChanged(NavigationView sender,
        NavigationViewSelectionChangedEventArgs args)
    {
        if (args.IsSettingsSelected)
        {
            contentFrame.Navigate(typeof(SettingsPage));
        }
        else
        {
            var selectedItem = args.SelectedItem as NavigationViewItem;
            if (selectedItem != null)
            {
                var selectedItemTag = (string) selectedItem.Tag;
                var pageName = "MasteriesQuest.Pages." + selectedItemTag;
                var pageType = Type.GetType(pageName);
                contentFrame.Navigate(pageType);
            }
        }
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
        }
    }

    public void Navigate(Type sourcePageType, object? parameter)
    {
        MainNavigationView.SelectedItem = null;
        contentFrame.Navigate(sourcePageType, parameter);
        contentFrame.Focus(FocusState.Programmatic);
    }

    private void SummonerSearchBox_OnSearchClicked(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrEmpty(SummonerSearchBox.SummonerSearch.SummonerName)) return;
        Navigate(typeof(SummonerPage), SummonerSearchBox.SummonerSearch.SummonerName);
        SummonerSearchBox.SummonerSearch.SummonerName = null;
    }
}