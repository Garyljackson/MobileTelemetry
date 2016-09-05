using System;
using System.Threading.Tasks;
using MobileTelemetry.Models;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace MobileTelemetry.Location
{
    public sealed class LocationManager : ILocationManager
    {
        private static readonly Lazy<LocationManager> InternalInstance = new Lazy<LocationManager>(LocationManagerFactory);
        private static readonly IGeolocator Geolocator;
        public event EventHandler<LocationUpdatedEventArgs> LocationUpdated;

        static LocationManager()
        {
            Geolocator = CrossGeolocator.Current;
            Geolocator.DesiredAccuracy = 10;
            Geolocator.AllowsBackgroundUpdates = true;
            Geolocator.PausesLocationUpdatesAutomatically = false;
        }

        public static LocationManager Instance { get; } = InternalInstance.Value;

        private void GeolocatorOnPositionChanged(object sender, PositionEventArgs e)
        {
            var position = e.Position.Transform();
            OnPositionUpdated(new LocationUpdatedEventArgs(position));
        }

        public async Task<bool> StartLocationUpdatesAsync(TimeSpan minTime, double minDistanceMeters, bool includeHeading)
        {
            Geolocator.PositionChanged += GeolocatorOnPositionChanged;
            return await Geolocator.StartListeningAsync(minTime.Milliseconds, minDistanceMeters, includeHeading);
        }

        public async Task<bool> StopLocationUpdatesAsync()
        {
            Geolocator.PositionChanged -= GeolocatorOnPositionChanged;
            return await Geolocator.StopListeningAsync();
        }
        
        public bool IsListening => Geolocator.IsListening;

        private void OnPositionUpdated(LocationUpdatedEventArgs e)
        {
            LocationUpdated?.Invoke(this, e);
        }

        private static LocationManager LocationManagerFactory()
        {
            return new LocationManager();
        }
    }
}