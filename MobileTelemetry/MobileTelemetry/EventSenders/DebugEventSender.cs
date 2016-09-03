using System.Threading.Tasks;
using MobileTelemetry.Models;

namespace MobileTelemetry.EventSenders
{
    public class DebugEventSender : IEventSender<TripPosition>
    {

        public Task SendEvent<T>(T data)
        {
            throw new System.NotImplementedException();
        }

        public Task SendEvent(TripPosition data)
        {
            var output = $"Position Updated: {data.Position.Timestamp}, Lon:{data.Position.Longitude} Lat:{data.Position.Latitude}";

            System.Diagnostics.Debug.WriteLine(output);
            return Task.FromResult(0);
        }
    }
}