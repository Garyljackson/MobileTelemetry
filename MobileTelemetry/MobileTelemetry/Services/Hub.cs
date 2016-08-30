using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using MobileTelemetry.Abstractions;
using Newtonsoft.Json;

namespace MobileTelemetry.Services
{
    public class Hub : IHub
    {
        private readonly DeviceClient _deviceClient;

        public Hub(DeviceClient deviceClient)
        {
            _deviceClient = deviceClient;
        }

        public async Task SendEvent<T>(T data)
        {
            if (_deviceClient == null)
                return;

            var dataString = JsonConvert.SerializeObject(data);
            var message = new Message(Encoding.UTF8.GetBytes(dataString));
            await _deviceClient.SendEventAsync(message);
        }
    }
}