using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MasteriesQuest.Controls;

public sealed partial class FeaturedGames : UserControl
{
    public FeaturedGames()
    {
        InitializeComponent();
    }

    public FeaturedGamesViewModel ViewModel { get; set; } = new();
}