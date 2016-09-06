using System;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Azure.Devices.Client;
using MobileTelemetry.Models;
using Newtonsoft.Json;

namespace MobileTelemetry.EventSenders
{
    public class AzureIotEventSender : IEventSender<TripLocation>
    {
        private readonly DeviceClient _deviceClient;

        public AzureIotEventSender(string connectionString)
        {
            _deviceClient = DeviceClient.CreateFromConnectionString(connectionString);
        }

        public async Task SendEvent(TripLocation data)
        {
            var dataString = JsonConvert.SerializeObject(data);
            var message = new Message(Encoding.UTF8.GetBytes(dataString));
            try
            {
                if (_deviceClient != null)
                {
                    await _deviceClient.SendEventAsync(message);
                }
                else
                {
                    Debug.WriteLine("Connection To IoT Hub is not established. Cannot send message now");
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine("Exception while sending message to IoT Hub:\n" + e.Message);
            }
        }
    }
}