using MobileTelemetry.Location;

namespace MobileTelemetry.EventRouter
{
    public class LocationEventRouterSingleton
    {
        static LocationEventRouterSingleton()
        {
            Instance = new LocationEventRouter(SingletonLocationManager.Instance);
        }

        private LocationEventRouterSingleton()
        {
        }

        public static LocationEventRouter Instance { get; private set; }
    }
}