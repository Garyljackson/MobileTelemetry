using System;
using System.Threading.Tasks;
using MobileTelemetry.Models;

namespace MobileTelemetry.Location
{
    public interface ILocationManager
    {
        event EventHandler<LocationUpdatedEventArgs> LocationUpdated;
        bool IsListening { get; }
        Task<bool> StartLocationUpdatesAsync(TimeSpan minTime, double minDistanceMeters, bool includeHeading);
        Task<bool> StopLocationUpdatesAsync();
    }
}