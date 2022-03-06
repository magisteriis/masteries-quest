using Windows.System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Automation.Peers;
using Microsoft.UI.Xaml.Automation.Provider;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Input;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MasteriesQuest.Controls;

public sealed partial class SummonerSearchBox : UserControl
{
    public SummonerSearchBox()
    {
        InitializeComponent();

        // Until fixed
        //SummonerSearch.Server = Server.NA;
        ServeComboBox.IsEnabled = false;
    }

    public SummonerSearchViewModel SummonerSearch { get; set; } = new();

    public event RoutedEventHandler SearchClicked
    {
        add => SearchButton.Click += value;
        remove => SearchButton.Click -= value;
    }

    private void SummonerNameTextBox_OnPreviewKeyDown(object sender, KeyRoutedEventArgs e)
    {
        if (e.Key == VirtualKey.Enter)
        {
            ButtonAutomationPeer peer = new ButtonAutomationPeer(SearchButton);
            IInvokeProvider invokeProv = peer.GetPattern(PatternInterface.Invoke) as IInvokeProvider;
            invokeProv.Invoke();
            e.Handled = true;
        }
    }
}