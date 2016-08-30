using System.Threading.Tasks;
using MobileTelemetry.Abstractions;
using MobileTelemetry.Models;

namespace MobileTelemetry.Services
{
    public class ConsoleTripPositionPublisher : ITripPositionPublisher
    {
        public Task Publish(TripPosition tripPosition)
        {
            return Task.FromResult(0);
        }
    }
}