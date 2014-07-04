using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace HookingProgram
{
    class Hooker
    {
        private static LowLevelKeyboardProc PROC = HookCallback;
        private static IntPtr HOOK_ID = IntPtr.Zero;

        private const int  WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;

        public void hooking()
        {
            HOOK_ID = SetHook(PROC);
            Application.Run();
            DllImporter.UnhookWindowsHookEx(HOOK_ID);
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                return DllImporter.SetWindowsHookEx(WH_KEYBOARD_LL, proc, DllImporter.GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        private static IntPtr HookCallback(int nCode, IntPtr wParam, IntPtr lParam)
        {
            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                int vkCode = Marshal.ReadInt32(lParam);

                String hookKey = ((Keys)vkCode).ToString();

                new FlowContorller().process(hookKey);
                //this function is print key result 
            }
            return DllImporter.CallNextHookEx(HOOK_ID, nCode, wParam, lParam);
        }

        public delegate IntPtr LowLevelKeyboardProc(int nCode, IntPtr wParam, IntPtr lParam);
    }
}
