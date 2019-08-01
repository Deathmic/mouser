namespace Mouser
{
    public class MouserSettings
    {
        public enum MoveModes
        {
            None = 0,
            FixedSpeed = 1,
            Accelerating = 2
        }

        public int LoopMilliseconds { get; set; } = 10;
        public int FixedMovePixels { get; set; } = 1;
        public int AccelerationTriggerMilliseconds { get; set; } = 200;
        public MoveModes MoveMode { get; set; } = MoveModes.Accelerating;
    }
}