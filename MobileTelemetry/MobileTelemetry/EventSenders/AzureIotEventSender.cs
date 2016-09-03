using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using MobileTelemetry.Models;
using Newtonsoft.Json;

namespace MobileTelemetry.EventSenders
{
    public class AzureIotEventSender : IEventSender<TripPosition>
    {
        private readonly DeviceClient _deviceClient;

        public AzureIotEventSender(string connectionString)
        {
            _deviceClient = DeviceClient.CreateFromConnectionString(connectionString);
        }

        public async Task SendEvent(TripPosition data)
        {
            var dataString = JsonConvert.SerializeObject(data);
            var message = new Message(Encoding.UTF8.GetBytes(dataString));
            await _deviceClient.SendEventAsync(message);
        }
    }
}