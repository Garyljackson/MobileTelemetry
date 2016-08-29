using System;
using MobileTelemetry.Models;

namespace MobileTelemetry
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