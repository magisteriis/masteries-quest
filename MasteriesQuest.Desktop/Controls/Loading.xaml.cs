using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MasteriesQuest.Controls;

public sealed partial class Loading : UserControl
{
    // Using a DependencyProperty as the backing store for IsLoading.  This enables animation, styling, binding, etc...
    public static readonly DependencyProperty IsLoadingProperty =
        DependencyProperty.Register("IsLoading", typeof(bool), typeof(Loading), new PropertyMetadata(0));

    public Loading()
    {
        InitializeComponent();
    }

    public bool IsLoading
    {
        get => (bool) GetValue(IsLoadingProperty);
        set => SetValue(IsLoadingProperty, value);
    }
}