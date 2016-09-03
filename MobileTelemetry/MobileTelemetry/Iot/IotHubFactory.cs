using Microsoft.Azure.Devices.Client;
using MobileTelemetry.Abstractions;

namespace MobileTelemetry.Iot
{
    public class IotHubFactory : IHubFactory
    {
        private readonly string _hubConnectionString;

        public IotHubFactory(string hubConnectionString)
        {
            _hubConnectionString = hubConnectionString;
        }


        public IHub Create()
        {
            var deviceClient = DeviceClient.CreateFromConnectionString(_hubConnectionString);
            return new IotHub(deviceClient);
        }
    }
}