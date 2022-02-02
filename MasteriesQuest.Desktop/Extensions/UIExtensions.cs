using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.System;

namespace MasteriesQuest
{
    internal static class UIExtensions
    {
        public static void AddKeyboardAccelerator(this UIElement element, VirtualKeyModifiers keyModifiers, VirtualKey key,
            TypedEventHandler<KeyboardAccelerator, KeyboardAcceleratorInvokedEventArgs> handler)
        {
            var accelerator =
                new KeyboardAccelerator()
                {
                    Modifiers = keyModifiers,
                    Key = key
                };
            accelerator.Invoked += handler;
            element.KeyboardAccelerators.Add(accelerator);
        }

        //public static void SetWindowIcon(this Window window, string iconName)
        //{
        //    //Get the Window's HWND
        //    var hwnd = WinRT.Interop.WindowNative.GetWindowHandle(window);
        //    var hIcon = PInvoke.User32.LoadImage(System.IntPtr.Zero, iconName,
        //                PInvoke.User32.ImageType.IMAGE_ICON, 16, 16, PInvoke.User32.LoadImageFlags.LR_LOADFROMFILE);

        //    PInvoke.User32.SendMessage(hwnd, PInvoke.User32.WindowMessage.WM_SETICON, (System.IntPtr)0, hIcon);
        //}
    }
}
