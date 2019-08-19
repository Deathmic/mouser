using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Mouser.Properties;

namespace Mouser.KeyboardCapturers
{
    public class KeyboardCapturer : IKeyboardCapturer
    {
        private const int WH_KEYBOARD_LL = 13;
        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP = 0x0101;

        private static IntPtr _ptrKeyboardHookId = IntPtr.Zero;

        public KeyboardCapturer()
        {
            _ptrKeyboardHookId = SetHook(KeyboardHookCallback);
        }

        public event EventHandler<KeyboardKeyEventArgs> KeyUp;
        public event EventHandler<KeyboardKeyEventArgs> KeyDown;

        public void Dispose()
        {
            ReleaseUnmanagedResources();
            GC.SuppressFinalize(this);
        }

        private void ReleaseUnmanagedResources()
        {
            if (_ptrKeyboardHookId != IntPtr.Zero) UnhookWindowsHookEx(_ptrKeyboardHookId);
        }

        ~KeyboardCapturer()
        {
            ReleaseUnmanagedResources();
        }

        private static IntPtr SetHook(LowLevelKeyboardProc proc)
        {
            using (var curProcess = Process.GetCurrentProcess())
            using (var curModule = curProcess.MainModule)
            {
                if (curModule != null)
                    return SetWindowsHookEx(WH_KEYBOARD_LL, proc, GetModuleHandle(curModule.ModuleName), 0);

                MessageBox.Show(
                    Resources.String_ErrorMessage_SetHookFailedCurrentProcessMainModuleWasNull,
                    Resources.String_Error,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return IntPtr.Zero;
            }
        }

        private IntPtr KeyboardHookCallback(int iCode, IntPtr wParam, IntPtr lParam)
        {
            if (iCode >= 0 && wParam == (IntPtr) WM_KEYDOWN)
            {
                var iKeyCode = Marshal.ReadInt32(lParam);
                var keyCode = (Keys) iKeyCode;
                KeyDown?.Invoke(this, new KeyboardKeyEventArgs(keyCode));
            }
            else if (iCode >= 0 && wParam == (IntPtr) WM_KEYUP)
            {
                var iKeyCode = Marshal.ReadInt32(lParam);
                var keyCode = (Keys) iKeyCode;
                KeyUp?.Invoke(this, new KeyboardKeyEventArgs(keyCode));
            }

            return CallNextHookEx(_ptrKeyboardHookId, iCode, wParam, lParam);
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr SetWindowsHookEx(
            int iHookCode,
            LowLevelKeyboardProc oCallback,
            IntPtr hMod,
            uint dwThreadId);


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        private static extern bool UnhookWindowsHookEx(IntPtr ptrHookId);

        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,
            IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        private static extern IntPtr GetModuleHandle(string lpModuleName);

        private delegate IntPtr LowLevelKeyboardProc(
            int nCode, IntPtr wParam, IntPtr lParam);
    }
}