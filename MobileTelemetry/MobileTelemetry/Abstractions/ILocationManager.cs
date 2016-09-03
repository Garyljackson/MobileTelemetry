using System;
using System.Threading.Tasks;
using MobileTelemetry.Models;

namespace MobileTelemetry.Abstractions
{
    public interface ILocationManager
    {
        event EventHandler<PositionUpdatedEventArgs> PositionUpdated;
        bool IsListening { get; }
        Task<bool> StartLocationUpdatesAsync(TimeSpan minTime, double minDistanceMeters, bool includeHeading);
        Task<bool> StopLocationUpdatesAsync();
    }
}