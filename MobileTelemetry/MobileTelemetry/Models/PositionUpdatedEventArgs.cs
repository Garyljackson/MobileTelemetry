using System;

namespace MobileTelemetry.Models
{
    public class PositionUpdatedEventArgs : EventArgs
    {
        public PositionUpdatedEventArgs(Position position)
        {
            Position = position;
        }

        public Position Position { get; private set; }
    }
}