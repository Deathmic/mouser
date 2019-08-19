using System;
using System.Windows.Forms;

namespace Mouser.KeyboardCapturers
{
    public class KeyboardKeyEventArgs : EventArgs
    {
        public KeyboardKeyEventArgs(Keys key)
        {
            Key = key;
        }

        public Keys Key { get; }
    }
}