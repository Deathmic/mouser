using System;

namespace Mouser.KeyboardCapturers
{
    public interface IKeyboardCapturer : IDisposable
    {
        event EventHandler<KeyboardKeyEventArgs> KeyUp;
        event EventHandler<KeyboardKeyEventArgs> KeyDown;
    }
}