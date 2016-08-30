using System;

namespace MobileTelemetry.Models
{
    public class TripPosition
    {
        public Guid Id { get; set; }
        public Position Position { get; set; }
    }
}