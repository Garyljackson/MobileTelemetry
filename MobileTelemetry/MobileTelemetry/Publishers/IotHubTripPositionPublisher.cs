using System.Threading.Tasks;
using MobileTelemetry.Abstractions;
using MobileTelemetry.Models;

namespace MobileTelemetry.Publishers
{
    public class IotHubTripPositionPublisher : ITripPositionPublisher
    {
        private readonly IHub _hub;

        public IotHubTripPositionPublisher(IHub hub)
        {
            _hub = hub;
        }

        public Task Publish(TripPosition tripPosition)
        {
            return _hub.SendEvent(tripPosition);
        }
    }
}