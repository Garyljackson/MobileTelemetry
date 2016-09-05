using System;
using MobileTelemetry.EventRouter;
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
            _locationManager = LocationManager.Instance;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            LoadSettings();
            segOnOff.ValueChanged += SegOnOff_ValueChanged;
        }

        private void LoadSettings()
        {
            if (!string.IsNullOrWhiteSpace(txtHubName.Text))
            {
                return;
            }

            txtHubName.Text = Settings.HubName;
            txtDeviceId.Text = Settings.DeviceId;
            txtAccessKey.Text = Settings.SharedAccessKey;
        }

        private void SaveSettings()
        {
            Settings.HubName = txtHubName.Text;
            Settings.DeviceId = txtDeviceId.Text;
            Settings.SharedAccessKey = txtAccessKey.Text;

        }

        private async void SegOnOff_ValueChanged(object sender, EventArgs e)
        {
            if (segOnOff.SelectedSegment == 0)
            {
                await _locationManager.StopLocationUpdatesAsync();
            }
            else if (segOnOff.SelectedSegment == 1)
            {
                SaveSettings();
                SetHubConfiguration();
                await _locationManager.StartLocationUpdatesAsync(TimeSpan.FromSeconds(5), 10, false);
            }
        }

        private void SetHubConfiguration()
        {
            var hubName = txtHubName.Text;
            var deviceId = txtDeviceId.Text;
            var sharedAccessKey = txtAccessKey.Text;

            var connectionString = $"HostName={hubName}.azure-devices.net;DeviceId={deviceId};SharedAccessKey={sharedAccessKey}";
            var eventSender = new AzureIotEventSender(connectionString);
            LocationEventRouter.Instance.SetEventSender(eventSender);
        }

    }
}