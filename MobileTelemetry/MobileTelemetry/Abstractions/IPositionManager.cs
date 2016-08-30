using System;
using System.Threading.Tasks;
using MobileTelemetry.Models;

namespace MobileTelemetry.Abstractions
{
    public interface IPositionManager
    {
        event EventHandler<PositionUpdatedEventArgs> PositionUpdated;
        bool IsListening { get; }
        Task<bool> StartLocationUpdatesAsync(TimeSpan minTime, double minDistanceMeters, bool includeHeading);
        Task<bool> StopLocationUpdatesAsync();
    }
}