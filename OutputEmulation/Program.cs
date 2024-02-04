using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;

class Program
{
    private const int INPUT_DELAY_MS = 80;

    [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
    [return: MarshalAs(UnmanagedType.Bool)]
    private static extern bool UnhookWindowsHookEx(IntPtr hhk);
    
    public static void Main()
    {
        Keyboard._hookIDKey = Keyboard.SetHook(Keyboard._procKey);
        Mouse._hookIDMouse = Mouse.SetHook(Mouse._procMouse);
        Application.Run();
        UnhookWindowsHookEx(Keyboard._hookIDKey);
        UnhookWindowsHookEx(Mouse._hookIDMouse);
    }
}
