using Windows.Foundation;
using Windows.System;
using Microsoft.UI.Xaml;
using Microsoft.UI.Xaml.Input;
using PInvoke;
using WinRT.Interop;

namespace MasteriesQuest;

internal static class UIExtensions
{
    public static void AddKeyboardAccelerator(this UIElement element, VirtualKeyModifiers keyModifiers, VirtualKey key,
        TypedEventHandler<KeyboardAccelerator, KeyboardAcceleratorInvokedEventArgs> handler)
    {
        var accelerator =
            new KeyboardAccelerator
            {
                Modifiers = keyModifiers,
                Key = key
            };
        accelerator.Invoked += handler;
        element.KeyboardAccelerators.Add(accelerator);
    }

    public static void SetWindowIcon(this Window window, string iconName)
    {
        //Get the Window's HWND
        var hwnd = WindowNative.GetWindowHandle(window);
        var smallIcon = User32.LoadImage(IntPtr.Zero, iconName,
            User32.ImageType.IMAGE_ICON, 16, 16, User32.LoadImageFlags.LR_LOADFROMFILE);
        var bigIcon = User32.LoadImage(IntPtr.Zero, iconName,
            User32.ImageType.IMAGE_ICON, 256, 256, User32.LoadImageFlags.LR_LOADFROMFILE);

        User32.SendMessage(hwnd, User32.WindowMessage.WM_SETICON, (IntPtr) 0, smallIcon);
        User32.SendMessage(hwnd, User32.WindowMessage.WM_SETICON, (IntPtr) 1, bigIcon);
    }
}