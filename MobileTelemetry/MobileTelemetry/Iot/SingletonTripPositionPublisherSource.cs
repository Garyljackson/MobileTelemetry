using MobileTelemetry.Abstractions;
using MobileTelemetry.Location;

namespace MobileTelemetry.Iot
{
    public class SingletonTripPositionPublisherSource
    {
        private SingletonTripPositionPublisherSource()
        {
        }

        public static TripPositionPublisherSource Intance { get; } = new TripPositionPublisherSource(SingletonPositionManager.Instance);

        public ITripPositionPublisher TripPositionPublisher
        {
            get { return Intance.TripPositionPublisher; }
            set { Intance.TripPositionPublisher = value; }
        }
    }
}