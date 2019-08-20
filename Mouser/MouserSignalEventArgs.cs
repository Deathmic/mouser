using System;

namespace Mouser
{
    public class MouserSignalEventArgs : EventArgs
    {
        public MouserSignalEventArgs(Mouser.Signals signal)
        {
            Signal = signal;
        }

        public Mouser.Signals Signal { get; }
    }
}