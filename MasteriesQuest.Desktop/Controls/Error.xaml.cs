using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Controls;
using Microsoft.UI.Xaml.Controls.Primitives;
using Microsoft.UI.Xaml.Data;
using Microsoft.UI.Xaml.Input;
using Microsoft.UI.Xaml.Media;
using Microsoft.UI.Xaml.Media.Imaging;
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

namespace MasteriesQuest.Controls
{
    public enum ErrorReason
    {
        Error,
        NotFound,
        RateLimit
    }

    public sealed partial class Error : UserControl
    {
        public Error()
        {
            this.InitializeComponent();
            this.Visibility = Visibility.Collapsed;
        }

        public ErrorReason Reason
        {
            get => (ErrorReason)GetValue(ReasonProperty);
            set
            {
                SetValue(ReasonProperty, value);
                switch (value)
                {
                    case ErrorReason.NotFound:
                        ReasonPhrase = "Couldn't find what you were looking for...";
                        ImageSource = new BitmapImage(Emotes.NotFound.Random());
                        break;
                    case ErrorReason.RateLimit:
                        ReasonPhrase = "Ouch. We've reached the limits of Riot's API. Try again later...";
                        ImageSource = new BitmapImage(Emotes.RateLimit.Random());
                        break;
                    case ErrorReason.Error:
                    default:
                        ReasonPhrase = "Something unexpected happened. Please open a GitHub issue!";
                        ImageSource = new BitmapImage(Emotes.Error.Random());
                        break;
                }
            }
        }

        public string ReasonPhrase
        {
            get => (string)GetValue(ReasonPhraseProperty);
            set => SetValue(ReasonPhraseProperty, value);
        }

        public ImageSource ImageSource
        {
            get => (ImageSource)GetValue(ImageSourceProperty);
            set => SetValue(ImageSourceProperty, value);
        }

        public void Show() => Visibility = Visibility.Visible;

        public void Show(Exception ex)
        {
            if (ex.Message != null)
            {
                if (ex.Message.Contains("429"))
                    Reason = Controls.ErrorReason.RateLimit;
                else if (ex.Message.Contains("404"))
                    Reason = ErrorReason.NotFound;
                else
                    Reason = ErrorReason.Error;
            }
            else
                Reason = ErrorReason.Error;

            Show();
        }

        public void Hide() => Visibility = Visibility.Collapsed;

        // Using a DependencyProperty as the backing store for Reason.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ReasonProperty =
            DependencyProperty.Register("Reason", typeof(ErrorReason), typeof(Error), new PropertyMetadata(0));

        // Using a DependencyProperty as the backing store for ImageSource.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ImageSourceProperty =
            DependencyProperty.Register("ImageSource", typeof(ImageSource), typeof(Error), new PropertyMetadata(0));

        // Using a DependencyProperty as the backing store for ReasonPhrase.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ReasonPhraseProperty =
            DependencyProperty.Register("ReasonPhrase", typeof(string), typeof(Error), new PropertyMetadata(0));
    }
}
