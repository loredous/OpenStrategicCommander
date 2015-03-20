using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Windows.Forms;

namespace OpenStrategicCommander.Classes
{

    
    class KeySend
    {
        [DllImport("user32.dll", SetLastError = true)]
        static extern bool SendMessage(IntPtr hWnd, uint Msg, int wParam, IntPtr lParam);

        [DllImport("user32.dll")]
        private static extern IntPtr GetForegroundWindow();

        const uint WM_KEYUP = 0x0101;
        const uint WM_KEYDOWN = 0x0100;

        public static void SendKey(Keys keys)
        {
            KeysConverter y = new KeysConverter();
            SendMessage(GetForegroundWindow(), WM_KEYDOWN, (int)keys, IntPtr.Zero);
            SendMessage(GetForegroundWindow(), WM_KEYUP, (int)keys, IntPtr.Zero);
        }
    }
}
