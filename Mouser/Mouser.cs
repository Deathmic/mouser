using System;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Mouser
{
    public class Mouser
    {
        private const int MOUSEEVENTF_MOVE = 0x0001;
        private readonly Timer _timer = new Timer();

        private bool _bActive;
        private DateTime _dtKeyHeldSince;
        private Keys _keyHeld;
        private MouserSettings _settings;

        public Mouser()
        {
            _timer.Tick += MainLoopTick;
        }

        [DllImport("user32.dll")]
        private static extern void mouse_event(int dwFlags, int dx, int dy, int dwData, int dwExtraInfo);

        private void MainLoopTick(object sender, EventArgs e)
        {
            if (!_bActive) return;

            if (_keyHeld == Keys.None) return;

            var iDistance = _settings.FixedMovePixels;

            if (_settings.MoveMode == MouserSettings.MoveModes.Accelerating)
            {
                var tsDiff = DateTime.Now - _dtKeyHeldSince;
                var iAccelerations = 1 + (int)(tsDiff.TotalMilliseconds / _settings.AccelerationTriggerMilliseconds);
                
                Debug.WriteLine($"{iAccelerations} accelerations ({tsDiff.TotalMilliseconds} ms)");
                
                iDistance *= iAccelerations;
            }

            var iRight = 0;
            var iDown = 0;

            switch (_keyHeld)
            {
                case Keys.NumPad1:
                    iRight = -iDistance;
                    iDown = iDistance;
                    break;

                case Keys.NumPad2:
                    iDown = iDistance;
                    break;

                case Keys.NumPad3:
                    iRight = iDistance;
                    iDown = iDistance;
                    break;

                case Keys.NumPad4:
                    iRight = -iDistance;
                    break;

                case Keys.NumPad6:
                    iRight = iDistance;
                    break;

                case Keys.NumPad7:
                    iRight = -iDistance;
                    iDown = -iDistance;
                    break;

                case Keys.NumPad8:
                    iDown = -iDistance;
                    break;

                case Keys.NumPad9:
                    iRight = iDistance;
                    iDown = -iDistance;
                    break;
            }

            MoveMouse(iRight, iDown);
        }

        public void SetSettings(MouserSettings settings)
        {
            _settings = settings;
        }

        public void Start()
        {
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
            Debug.WriteLine($"Moving mouse: {iRight} | {iDown}");
            
            mouse_event(MOUSEEVENTF_MOVE, iRight, iDown, 0, 0);
        }

        public void KeyDown(Keys key)
        {
            if (key == _keyHeld) return;

            Debug.WriteLine($"Key down: {key}");
            
            _keyHeld = key;
            _dtKeyHeldSince = DateTime.Now;
        }

        public void KeyUp(Keys key)
        {
            if (key == _keyHeld)
            {
                Debug.WriteLine($"Key up: {key}");
                _keyHeld = Keys.None;
            }
        }
    }
}