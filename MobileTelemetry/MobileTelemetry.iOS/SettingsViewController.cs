using System;
using MobileTelemetry.Abstractions;
using MobileTelemetry.EventPublishers;
using MobileTelemetry.EventSenders;
using MobileTelemetry.Location;
using UIKit;

namespace MobileTelemetry.iOS
{
    public partial class SettingsViewController : UIViewController
    {
        private readonly ILocationManager _locationManager;

        public SettingsViewController(IntPtr handle) : base(handle)
        {
            _locationManager = SingletonLocationManager.Instance;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            segOnOff.ValueChanged += SegOnOff_ValueChanged;
        }

        private async void SegOnOff_ValueChanged(object sender, EventArgs e)
        {
            if (segOnOff.SelectedSegment == 0)
            {
                await _locationManager.StopLocationUpdatesAsync();
            }
            else if (segOnOff.SelectedSegment == 1)
            {
                SetHubConfiguration();
                await _locationManager.StartLocationUpdatesAsync(TimeSpan.FromSeconds(5), 10, false);
            }
        }

        private void SetHubConfiguration()
        {
            var connectionString = $"HostName={txtHubName.Text}.azure-devices.net;DeviceId={txtDeviceId.Text};SharedAccessKey={txtAccessKey.Text}";
            var eventSender = new AzureIotEventSender(connectionString);
            PositionEventPublisherSingleton.Instance.SetEventSender(eventSender);
        }
    }
}