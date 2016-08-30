using System;
using System.Threading.Tasks;
using MobileTelemetry.Abstractions;
using MobileTelemetry.Models;
using Plugin.Geolocator.Abstractions;

namespace MobileTelemetry.Services
{
    public class PositionManager : IPositionManager
    {
        private readonly IGeolocator _geolocator;
        public event EventHandler<PositionUpdatedEventArgs> PositionUpdated;

        public PositionManager(IGeolocator geolocator)
        {
            _geolocator = geolocator;
            _geolocator.AllowsBackgroundUpdates = true;
        }

        private void GeolocatorOnPositionChanged(object sender, PositionEventArgs e)
        {
            var position = e.Position.Transform();
            OnPositionUpdated(new PositionUpdatedEventArgs(position));
        }

        public async Task<bool> StartLocationUpdatesAsync(TimeSpan minTime, double minDistanceMeters, bool includeHeading)
        {
            _geolocator.PositionChanged += GeolocatorOnPositionChanged;
            return await _geolocator.StartListeningAsync(minTime.Milliseconds, minDistanceMeters, includeHeading);
        }

        public async Task<bool> StopLocationUpdatesAsync()
        {
            _geolocator.PositionChanged -= GeolocatorOnPositionChanged;
            return await _geolocator.StopListeningAsync();
        }
        
        public bool IsListening => _geolocator.IsListening;

        private void OnPositionUpdated(PositionUpdatedEventArgs e)
        {
            PositionUpdated?.Invoke(this, e);
        }
    }
}