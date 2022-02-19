using CommunityToolkit.WinUI.UI.Controls;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MasteriesQuest.Controls;

public sealed partial class MasteriesGrid : UserControl
{
    // Using a DependencyProperty as the backing store for MasteriesSource.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty MasteriesSourceProperty =
        DependencyProperty.Register("MasteriesSource", typeof(ObservableCollection<ChampionMasteryViewModel>),
            typeof(MasteriesGrid), new PropertyMetadata(0));

    public MasteriesGrid()
    {
        InitializeComponent();
        DataContext = this;
    }

    public ObservableCollection<ChampionMasteryViewModel> MasteriesSource
    {
        get => (ObservableCollection<ChampionMasteryViewModel>) GetValue(MasteriesSourceProperty);
        set => SetValue(MasteriesSourceProperty, value);
    }

    private void MasteriesDataGrid_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
    {
        switch (e.Column.Header.ToString())
        {
            case nameof(ChampionMastery.ChestGranted):
                e.Column.Header = "Chest";
                break;

            case nameof(ChampionMastery.ChampionId):
                e.Column.Header = "Champion";
                break;

            case nameof(ChampionMastery.LastPlayTime):
                e.Column.Header = "Last Played";
                break;

            case nameof(ChampionMastery.ChampionLevel):
                e.Column.Header = "Level";
                break;

            case nameof(ChampionMastery.ChampionPoints):
                e.Column.Header = "Points";
                break;

            default:
                e.Cancel = true;
                break;
        }
    }
}