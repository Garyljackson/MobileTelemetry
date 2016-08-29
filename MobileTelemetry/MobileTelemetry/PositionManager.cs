using System;
using System.Threading.Tasks;
using Plugin.Geolocator;
using Plugin.Geolocator.Abstractions;

namespace MobileTelemetry
{
    public class PositionManager
    {
        private static readonly IGeolocator Geolocator;
        public event EventHandler<PositionUpdatedEventArgs> PositionUpdated;
        public static PositionManager Instance { get; } = new PositionManager();

        static PositionManager()
        {
            Geolocator = CrossGeolocator.Current;
            Geolocator.AllowsBackgroundUpdates = true;
        }

        private PositionManager()
        { }

        private void GeolocatorOnPositionChanged(object sender, PositionEventArgs e)
        {
            var position = e.Position.Transform();
            OnPositionUpdated(new PositionUpdatedEventArgs(position));
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

        private void OnPositionUpdated(PositionUpdatedEventArgs e)
        {
            PositionUpdated?.Invoke(this, e);
        }
    }
}