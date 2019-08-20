using System;
using System.Windows.Forms;
using Mouser.KeyboardCapturers;
using Mouser.Loggers;
using Mouser.MouseWrappers;

namespace Mouser
{
    public class Mouser : IDisposable
    {
        public enum MouseActions
        {
            None = 0,
            MoveUpLeft,
            MoveUp,
            MoveUpRight,
            MoveRight,
            MoveDownRight,
            MoveDown,
            MoveDownLeft,
            MoveLeft,
            LeftClick,
            RightClick,
            MiddleClick,
            Button4Click,
            Button5Click,
            Button6Click,
            Button7Click,
            LeftDoubleClick,
            RightDoubleClick,
            MiddleDoubleClick,
            Button4DoubleClick,
            Button5DoubleClick,
            Button6DoubleClick,
            Button7DoubleClick,
            LeftDown,
            RightDown,
            MiddleDown,
            Button4Down,
            Button5Down,
            Button6Down,
            Button7Down,
            LeftUp,
            RightUp,
            MiddleUp,
            Button4Up,
            Button5Up,
            Button6Up,
            Button7Up
        }

        public enum MouseButtons
        {
            Left,
            Right,
            Middle,
            Button4,
            Button5,
            Button6,
            Button7
        }

        public enum Signals
        {
            Start,
            Stop,
        }

        private readonly IKeyboardCapturer _keyboardCapturer;
        private readonly ILogger _logger;
        private readonly IMouseWrapper _mouseWrapper;

        private readonly Timer _timer = new Timer();

        private bool _bActive;
        private DateTime _dtKeyHeldSince;
        private Keys _keyHeld;
        private MouserSettings _settings;

        public Mouser(IMouseWrapper mouseWrapper, IKeyboardCapturer keyboardCapturer, ILogger logger)
        {
            _mouseWrapper = mouseWrapper;
            _keyboardCapturer = keyboardCapturer;
            _logger = logger;

            logger.Debug("Initializing Mouser class.");

            _keyboardCapturer.KeyUp += (sender, args) => KeyUp(args.Key);
            _keyboardCapturer.KeyDown += (sender, args) => KeyDown(args.Key);

            _timer.Tick += MainLoopTick;
        }

        public void Dispose()
        {
            _logger.Debug("Disposing of Mouser class.");

            Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void MainLoopTick(object sender, EventArgs e)
        {
            if (!_bActive) return;

            if (_keyHeld == Keys.None) return;

            var mouseAction = GetMouseAction(_keyHeld);

            if (mouseAction == MouseActions.None) return;

            PerformMouseAction(mouseAction);
        }

        public void PerformMouseAction(MouseActions mouseAction)
        {
            int iDistance;

            switch (mouseAction)
            {
                case MouseActions.MoveUpLeft:
                    iDistance = CalculateMoveDistance();
                    MoveMouse(-iDistance, -iDistance);
                    break;
                case MouseActions.MoveUp:
                    iDistance = CalculateMoveDistance();
                    MoveMouse(0, -iDistance);
                    break;
                case MouseActions.MoveUpRight:
                    iDistance = CalculateMoveDistance();
                    MoveMouse(iDistance, -iDistance);
                    break;
                case MouseActions.MoveRight:
                    iDistance = CalculateMoveDistance();
                    MoveMouse(iDistance, 0);
                    break;
                case MouseActions.MoveDownRight:
                    iDistance = CalculateMoveDistance();
                    MoveMouse(iDistance, iDistance);
                    break;
                case MouseActions.MoveDown:
                    iDistance = CalculateMoveDistance();
                    MoveMouse(0, iDistance);
                    break;
                case MouseActions.MoveDownLeft:
                    iDistance = CalculateMoveDistance();
                    MoveMouse(-iDistance, iDistance);
                    break;
                case MouseActions.MoveLeft:
                    iDistance = CalculateMoveDistance();
                    MoveMouse(-iDistance, 0);
                    break;
                case MouseActions.LeftClick:
                    MouseButtonDown(MouseButtons.Left);
                    MouseButtonUp(MouseButtons.Left);
                    break;
                case MouseActions.RightClick:
                    MouseButtonDown(MouseButtons.Right);
                    MouseButtonUp(MouseButtons.Right);
                    break;
                case MouseActions.MiddleClick:
                    MouseButtonDown(MouseButtons.Middle);
                    MouseButtonUp(MouseButtons.Middle);
                    break;
                case MouseActions.Button4Click:
                    MouseButtonDown(MouseButtons.Button4);
                    MouseButtonUp(MouseButtons.Button4);
                    break;
                case MouseActions.Button5Click:
                    MouseButtonDown(MouseButtons.Button5);
                    MouseButtonUp(MouseButtons.Button5);
                    break;
                case MouseActions.Button6Click:
                    MouseButtonDown(MouseButtons.Button6);
                    MouseButtonUp(MouseButtons.Button6);
                    break;
                case MouseActions.Button7Click:
                    MouseButtonDown(MouseButtons.Button7);
                    MouseButtonUp(MouseButtons.Button7);
                    break;
                case MouseActions.LeftDoubleClick:
                    MouseButtonDown(MouseButtons.Left);
                    MouseButtonUp(MouseButtons.Left);
                    MouseButtonDown(MouseButtons.Left);
                    MouseButtonUp(MouseButtons.Left);
                    break;
                case MouseActions.RightDoubleClick:
                    MouseButtonDown(MouseButtons.Right);
                    MouseButtonUp(MouseButtons.Right);
                    MouseButtonDown(MouseButtons.Right);
                    MouseButtonUp(MouseButtons.Right);
                    break;
                case MouseActions.MiddleDoubleClick:
                    MouseButtonDown(MouseButtons.Middle);
                    MouseButtonUp(MouseButtons.Middle);
                    MouseButtonDown(MouseButtons.Middle);
                    MouseButtonUp(MouseButtons.Middle);
                    break;
                case MouseActions.Button4DoubleClick:
                    MouseButtonDown(MouseButtons.Button4);
                    MouseButtonUp(MouseButtons.Button4);
                    MouseButtonDown(MouseButtons.Button4);
                    MouseButtonUp(MouseButtons.Button4);
                    break;
                case MouseActions.Button5DoubleClick:
                    MouseButtonDown(MouseButtons.Button5);
                    MouseButtonUp(MouseButtons.Button5);
                    MouseButtonDown(MouseButtons.Button5);
                    MouseButtonUp(MouseButtons.Button5);
                    break;
                case MouseActions.Button6DoubleClick:
                    MouseButtonDown(MouseButtons.Button6);
                    MouseButtonUp(MouseButtons.Button6);
                    MouseButtonDown(MouseButtons.Button6);
                    MouseButtonUp(MouseButtons.Button6);
                    break;
                case MouseActions.Button7DoubleClick:
                    MouseButtonDown(MouseButtons.Button7);
                    MouseButtonUp(MouseButtons.Button7);
                    MouseButtonDown(MouseButtons.Button7);
                    MouseButtonUp(MouseButtons.Button7);
                    break;
                case MouseActions.LeftDown:
                    MouseButtonDown(MouseButtons.Left);
                    break;
                case MouseActions.RightDown:
                    MouseButtonDown(MouseButtons.Right);
                    break;
                case MouseActions.MiddleDown:
                    MouseButtonDown(MouseButtons.Middle);
                    break;
                case MouseActions.Button4Down:
                    MouseButtonDown(MouseButtons.Button4);
                    break;
                case MouseActions.Button5Down:
                    MouseButtonDown(MouseButtons.Button5);
                    break;
                case MouseActions.Button6Down:
                    MouseButtonDown(MouseButtons.Button6);
                    break;
                case MouseActions.Button7Down:
                    MouseButtonDown(MouseButtons.Button7);
                    break;
                case MouseActions.LeftUp:
                    MouseButtonUp(MouseButtons.Left);
                    break;
                case MouseActions.RightUp:
                    MouseButtonUp(MouseButtons.Right);
                    break;
                case MouseActions.MiddleUp:
                    MouseButtonUp(MouseButtons.Middle);
                    break;
                case MouseActions.Button4Up:
                    MouseButtonUp(MouseButtons.Button4);
                    break;
                case MouseActions.Button5Up:
                    MouseButtonUp(MouseButtons.Button5);
                    break;
                case MouseActions.Button6Up:
                    MouseButtonUp(MouseButtons.Button6);
                    break;
                case MouseActions.Button7Up:
                    MouseButtonUp(MouseButtons.Button7);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private int CalculateMoveDistance()
        {
            var iDistance = _settings.FixedMovePixels;

            if (_settings.MoveMode == MouserSettings.MoveModes.Accelerating)
            {
                var tsDiff = DateTime.Now - _dtKeyHeldSince;
                var iAccelerations = 1 + (int) (tsDiff.TotalMilliseconds / _settings.AccelerationTriggerMilliseconds);

                _logger.Debug(
                    $"{iAccelerations} accelerations ({tsDiff.TotalMilliseconds} ms / {_settings.AccelerationTriggerMilliseconds} ms)");

                iDistance *= iAccelerations;
            }

            return iDistance;
        }

        private void MouseButtonUp(MouseButtons mouseButton)
        {
            _logger.Debug($"Releasing mouse button: {mouseButton}");

            _mouseWrapper.ButtonUp(mouseButton);
        }

        private void MouseButtonDown(MouseButtons mouseButton)
        {
            _logger.Debug($"Pressing mouse button down: {mouseButton}");

            _mouseWrapper.ButtonDown(mouseButton);
        }

        private MouseActions GetMouseAction(Keys key)
        {
            return _settings.KeyActions.ContainsKey(key) ? _settings.KeyActions[key] : MouseActions.None;
        }

        public void SetSettings(MouserSettings settings)
        {
            _settings = settings;
        }

        public void Start(MouserSettings settings)
        {
            _settings = settings;

            _bActive = true;

            _timer.Interval = _settings.LoopMilliseconds;
            _timer.Start();
        }

        public void Stop()
        {
            _bActive = false;
            _timer.Stop();
        }

        private void MoveMouse(int iRight, int iDown)
        {
            _logger.Debug($"Moving mouse: {iRight} right, {iDown} down");

            _mouseWrapper.Move(iRight, iDown);
        }

        public void KeyDown(Keys key)
        {
            if (key == _keyHeld) return;

            _logger.Debug($"Key down: {key}");

            _keyHeld = key;
            _dtKeyHeldSince = DateTime.Now;
        }

        public void KeyUp(Keys key)
        {
            if (key == _keyHeld)
            {
                _logger.Debug($"Key up: {key}");
                _keyHeld = Keys.None;
            }
        }

        private void ReleaseUnmanagedResources()
        {
            // TODO release unmanaged resources here
        }

        private void Dispose(bool disposing)
        {
            ReleaseUnmanagedResources();
            if (disposing) _timer?.Dispose();
        }

        ~Mouser()
        {
            Dispose(false);
        }
    }
}