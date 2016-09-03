using System;

namespace MobileTelemetry.Models
{
    public class LocationUpdatedEventArgs : EventArgs
    {
        public LocationUpdatedEventArgs(Location location)
        {
            Location = location;
        }

        public Location Location { get; private set; }
    }
}