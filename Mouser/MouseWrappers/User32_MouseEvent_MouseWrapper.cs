using System;
using System.Runtime.InteropServices;

namespace Mouser.MouseWrappers
{
    public class User32_MouseEvent_MouseWrapper : IMouseWrapper
    {
        private const int MOUSEEVENTF_MOVE = 0x0001;

        public void Move(int iRight, int iDown)
        {
            mouse_event(MOUSEEVENTF_MOVE, iRight, iDown, 0, 0);
        }

        public void ButtonDown(Mouser.MouseButtons mouseButton)
        {
            throw new NotImplementedException();
        }

        public void ButtonUp(Mouser.MouseButtons mouseButton)
        {
            throw new NotImplementedException();
        }

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);
    }
}