using System.Threading.Tasks;
using MobileTelemetry.Abstractions;
using MobileTelemetry.Models;

namespace MobileTelemetry.Publishers
{
    public class DebugTripPositionPublisher : ITripPositionPublisher
    {
        public Task Publish(TripPosition tripPosition)
        {
            var output = $"Position Updated: {tripPosition.Position.Timestamp}, Lon:{tripPosition.Position.Longitude} Lat:{tripPosition.Position.Latitude}";

            System.Diagnostics.Debug.WriteLine(output);
            return Task.FromResult(0);
        }
    }
}