using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Navigation;
using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;

// To learn more about WinUI, the WinUI project structure,
// and more about our project templates, see: http://aka.ms/winui-project-info.

namespace MasteriesQuest.Controls
{
    public sealed partial class MasteriesGrid : UserControl
    {
        public MasteriesGrid()
        {
            this.InitializeComponent();
            this.DataContext = this;
        }

        public IEnumerable MasteriesSource
        {
            get { return (IEnumerable)GetValue(MasteriesSourceProperty); }
            set { SetValue(MasteriesSourceProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MasteriesSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty MasteriesSourceProperty =
            DependencyProperty.Register("MasteriesSource", typeof(IEnumerable), typeof(MasteriesGrid), new PropertyMetadata(0));
    }
}
