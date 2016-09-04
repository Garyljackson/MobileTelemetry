using System;
using System.Threading.Tasks;
using MobileTelemetry.Models;
using Plugin.Geolocator.Abstractions;

namespace MobileTelemetry.Location
{
    public class LocationManager : ILocationManager
    {
        private readonly IGeolocator _geolocator;
        public event EventHandler<LocationUpdatedEventArgs> LocationUpdated;

        public LocationManager(IGeolocator geolocator)
        {
            _geolocator = geolocator;
            _geolocator.DesiredAccuracy = 10;
            _geolocator.AllowsBackgroundUpdates = true;
            _geolocator.PausesLocationUpdatesAutomatically = false;
        }

        private void GeolocatorOnPositionChanged(object sender, PositionEventArgs e)
        {
            var position = e.Position.Transform();
            OnPositionUpdated(new LocationUpdatedEventArgs(position));
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

        private void OnPositionUpdated(LocationUpdatedEventArgs e)
        {
            var lastValue = Settings.LastUpdate;
            var newEntry = e.Location.Timestamp.ToLocalTime().DateTime.ToString("T");

            Settings.LastUpdate = $"{lastValue}, {newEntry}";

            LocationUpdated?.Invoke(this, e);
        }
    }
}