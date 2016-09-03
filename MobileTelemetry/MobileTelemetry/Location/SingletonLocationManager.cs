using MobileTelemetry.Abstractions;
using Plugin.Geolocator;

namespace MobileTelemetry.Location
{
    public class SingletonLocationManager
    {
        static SingletonLocationManager()
        {
            Instance = new LocationManager(CrossGeolocator.Current);
        }

        private SingletonLocationManager()
        {
        }

        public static ILocationManager Instance { get; private set; }
    }
}