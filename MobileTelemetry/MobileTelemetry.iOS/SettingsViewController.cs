using System;
using MobileTelemetry.Abstractions;
using MobileTelemetry.Iot;
using MobileTelemetry.Location;
using MobileTelemetry.Publishers;
using UIKit;

namespace MobileTelemetry.iOS
{
    public partial class SettingsViewController : UIViewController
    {
        private readonly IPositionManager _positionManager;

        public SettingsViewController(IntPtr handle) : base(handle)
        {
            _positionManager = SingletonPositionManager.Instance;
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
                await _positionManager.StopLocationUpdatesAsync();
            }
            else if (segOnOff.SelectedSegment == 1)
            {
                SetHubConfiguration();
                await _positionManager.StartLocationUpdatesAsync(TimeSpan.FromSeconds(3), 5, false);
            }
        }

        private void SetHubConfiguration()
        {
            var connectionString = $"HostName={txtHubName.Text}.azure-devices.net;DeviceId={txtDeviceId.Text};SharedAccessKey={txtAccessKey.Text}";
            var hubFactory = new IotHubFactory(connectionString);

            var iotHubTripPositionPublisher = new IotHubTripPositionPublisher(hubFactory);
            SingletonTripPositionPublisherSource.Intance.TripPositionPublisher = iotHubTripPositionPublisher;

        }
    }
}