using System.Threading.Tasks;
using MobileTelemetry.Models;

namespace MobileTelemetry.Abstractions
{
    public interface ITripPositionPublisher
    {
        Task Publish(TripLocation tripLocation);
    }
}
