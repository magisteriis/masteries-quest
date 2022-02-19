using Windows.ApplicationModel.DataTransfer;
using Windows.System;
using Microsoft.UI;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MasteriesQuest.Pages;

/// <summary>
///     An empty page that can be used on its own or navigated to within a Frame.
/// </summary>
public sealed partial class ChampSelectPage : Page
{
    public ChampSelectPage()
    {
        InitializeComponent();
        _addGlobalHotKey(VirtualKeyModifiers.Control, VirtualKey.C, e => _copyAllSummoners());
    }

    public ObservableCollection<SummonerViewModel> Summoners { get; set; } = new();

    protected override void OnNavigatedTo(NavigationEventArgs e)
    {
        if (e.Parameter is string[] summonerNames)
            _ = Task.Run(async () =>
            {
                DispatcherQueue.TryEnqueue(() =>
                    MainGrid.Background = new SolidColorBrush(LcuHelper.TeamId == 1 ? Colors.Navy : Colors.DarkRed));
                try
                {
                    await _setSummonersAsync(summonerNames);
                    DispatcherQueue.TryEnqueue(() => Loading.IsLoading = false);
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

    private async Task _setSummonersAsync(params string[] summoners)
    {
        summoners = _filterExcludedSummoners(summoners);

        if (Summoners.Count != 0 && Summoners.All(s => summoners.Contains(s.Name)))
            return;

        Summoners.Clear();

        using var client = new LeagueOfLegendsClient("desktop", Server.EUW);

        Dictionary<SummonerViewModel, Task<LeagueOfLegendsReadOnlyCollection<ChampionMastery>>> tasks = new();
        foreach (var name in summoners)
        {
            var summoner = new SummonerViewModel(name);
            tasks.Add(summoner, Task.Run(async () =>
            {
                var summoner = await client.GetSummonerByNameAsync(name);
                return await client.GetChampionMasteriesAsync(summoner.Id);
            }));
            DispatcherQueue.TryEnqueue(() => Summoners.Add(summoner));
        }

        await Task.WhenAll(tasks.Values.ToArray());
        foreach (var (summonerViewModel, task) in tasks) DispatcherQueue.TryEnqueue(() => summonerViewModel.Populate(task.Result));
    }

    private static string[] _filterExcludedSummoners(string[] summoners)
    {
        //return summoners;
        return summoners.Where(x => x != "DevOps Activist").ToArray();
    }

    private void ScrollViewer_Holding(object sender, HoldingRoutedEventArgs e)
    {
    }

    private void _copyAllSummoners()
    {
        var message = ChatHelper.ComposeMasteriesSummary(Summoners);

        DataPackage dataPackage = new() {RequestedOperation = DataPackageOperation.Copy};
        dataPackage.SetText(message);
        Clipboard.SetContent(dataPackage);
    }

    private void _addGlobalHotKey(VirtualKeyModifiers keyModifiers, VirtualKey key,
        Action<KeyboardAcceleratorInvokedEventArgs> action)
    {
        MainGrid.AddKeyboardAccelerator(keyModifiers, key, (a, b) =>
        {
            action.Invoke(b);

            b.Handled = true;
        });
    }
}