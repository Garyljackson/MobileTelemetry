using MobileTelemetry.Location;

namespace MobileTelemetry.EventPublishers
{
    public class PositionEventPublisherSingleton
    {
        static PositionEventPublisherSingleton()
        {
            Instance = new PositionEventPublisher(SingletonLocationManager.Instance);
        }

        private PositionEventPublisherSingleton()
        {
        }

        public static PositionEventPublisher Instance { get; private set; }
    }
}