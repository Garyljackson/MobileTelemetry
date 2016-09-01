using Microsoft.Azure.Devices.Client;
using MobileTelemetry.Abstractions;

namespace MobileTelemetry.Iot
{
    public class HubFactory : IHubFactory
    {
        private readonly string _hubConnectionString;

        public HubFactory(string hubConnectionString)
        {
            _hubConnectionString = hubConnectionString;
        }

        public IHub Create()
        {
            var deviceClient = DeviceClient.CreateFromConnectionString(_hubConnectionString);
            return new Hub(deviceClient);
        }
    }
}