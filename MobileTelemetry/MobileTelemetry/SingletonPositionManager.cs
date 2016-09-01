using System;
using System.Threading.Tasks;
using MobileTelemetry.Abstractions;
using MobileTelemetry.Location;
using MobileTelemetry.Models;
using Plugin.Geolocator;

namespace MobileTelemetry
{
    public class SingletonPositionManager : IPositionManager
    {
        static SingletonPositionManager()
        {
        }

        private SingletonPositionManager()
        {
        }

        public static IPositionManager Instance { get; } = new PositionManager(CrossGeolocator.Current);

        public event EventHandler<PositionUpdatedEventArgs> PositionUpdated;

        public bool IsListening => Instance.IsListening;

        public Task<bool> StartLocationUpdatesAsync(TimeSpan minTime, double minDistanceMeters, bool includeHeading)
        {
            Instance.PositionUpdated += PositionUpdated;
            return Instance.StartLocationUpdatesAsync(minTime, minDistanceMeters, includeHeading);
        }

        public Task<bool> StopLocationUpdatesAsync()
        {
            Instance.PositionUpdated -= PositionUpdated;
            return Instance.StopLocationUpdatesAsync();
        }
    }
}