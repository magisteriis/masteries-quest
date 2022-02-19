using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MasteriesQuest.Controls;

public sealed partial class SummonerSearchBox : UserControl
{
    public SummonerSearchBox()
    {
        InitializeComponent();
    }

    public SummonerSearchViewModel SummonerSearch { get; set; } = new();
}