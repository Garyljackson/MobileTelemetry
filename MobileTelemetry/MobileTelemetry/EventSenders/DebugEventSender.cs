using System.Threading.Tasks;
using MobileTelemetry.Models;

namespace MobileTelemetry.EventSenders
{
    public class DebugEventSender : IEventSender<TripLocation>
    {

        public Task SendEvent<T>(T data)
        {
            throw new System.NotImplementedException();
        }

        public Task SendEvent(TripLocation data)
        {
            var output = $"Location Updated: {data.Location.Timestamp}, Lon:{data.Location.Longitude} Lat:{data.Location.Latitude}";

            System.Diagnostics.Debug.WriteLine(output);
            return Task.FromResult(0);
        }
    }
}