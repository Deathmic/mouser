using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Mouser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Debug.WriteLine("Initialized!");
            _hookID = SetHook(_proc);
            //UnhookWindowsHookEx(_hookID);
            
            var timer = new Timer();
            timer.Interval = 10;
            timer.Tick += TimerOnTick;
            timer.Start();
        }

        private void TimerOnTick(object sender, EventArgs e)
        {
            Debug.WriteLine("Tick");
            
            if (_left) Move(-1,0);
        }

        private const int WH_KEYBOARD_LL = 13;

        private const int WM_KEYDOWN = 0x0100;
        private const int WM_KEYUP= 0x0101;

        private static LowLevelKeyboardProc _proc = HookCallback;

        private static IntPtr _hookID = IntPtr.Zero;
        private static bool _left;


        private static IntPtr SetHook(LowLevelKeyboardProc proc)

        {

            using (Process curProcess = Process.GetCurrentProcess())

            using (ProcessModule curModule = curProcess.MainModule)

            {

                return SetWindowsHookEx(WH_KEYBOARD_LL, proc,

                    GetModuleHandle(curModule.ModuleName), 0);

            }

        }


        private delegate IntPtr LowLevelKeyboardProc(

            int nCode, IntPtr wParam, IntPtr lParam);


        private static IntPtr HookCallback(

            int nCode, IntPtr wParam, IntPtr lParam)

        {

            if (nCode >= 0 && wParam == (IntPtr)WM_KEYDOWN)
            {
                var iKeyCode = Marshal.ReadInt32(lParam);

                var keyCode = (Keys) iKeyCode;
                
                Debug.WriteLine(keyCode);

                if (keyCode == Keys.NumPad4)
                {
                    _left = true;
                    //Move(-10, 0);
                }
            }
            else if (nCode >= 0 && wParam == (IntPtr) WM_KEYUP)
            {
                var iKeyCode = Marshal.ReadInt32(lParam);

                var keyCode = (Keys) iKeyCode;
                
                Debug.WriteLine(keyCode);

                if (keyCode == Keys.NumPad4)
                {
                    _left = false;
                    //Move(-10, 0);
                }
            }

            return CallNextHookEx(_hookID, nCode, wParam, lParam);

        }
        
        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        private const int MOUSEEVENTF_MOVE = 0x0001;

        public static void Move(int xDelta, int yDelta)
        {
            mouse_event(MOUSEEVENTF_MOVE, xDelta, yDelta, 0, 0);
        }


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern IntPtr SetWindowsHookEx(int idHook,

            LowLevelKeyboardProc lpfn, IntPtr hMod, uint dwThreadId);
        
        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetCursorPos(out POINT lpPoint);

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int X;
            public int Y;

            public POINT(int X, int Y)
            {
                this.X = X;
                this.Y = Y;
            }
        }
        


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        [return: MarshalAs(UnmanagedType.Bool)]

        private static extern bool UnhookWindowsHookEx(IntPtr hhk);
        
        [DllImport("user32.dll")]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool SetCursorPos(int x, int y);


        [DllImport("user32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern IntPtr CallNextHookEx(IntPtr hhk, int nCode,

            IntPtr wParam, IntPtr lParam);


        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]

        private static extern IntPtr GetModuleHandle(string lpModuleName);
    }
    
        


}