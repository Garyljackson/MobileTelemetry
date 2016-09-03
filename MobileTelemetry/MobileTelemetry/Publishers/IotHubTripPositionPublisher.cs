using System.Threading.Tasks;
using MobileTelemetry.Abstractions;
using MobileTelemetry.Models;

namespace MobileTelemetry.Publishers
{
    public class IotHubTripPositionPublisher : ITripPositionPublisher
    {
        private readonly IHubFactory _hubFactory;
        private IHub _hub;

        public IotHubTripPositionPublisher(IHubFactory hubFactory)
        {
            _hubFactory = hubFactory;
        }

        public Task Publish(TripPosition tripPosition)
        {
            if (_hub == null)
            {
                _hub = _hubFactory.Create();
            }

            return _hub.SendEvent(tripPosition);
        }
    }
}