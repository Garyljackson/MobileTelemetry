using System;
using System.Collections.Generic;
using System.Linq;
using CoreGraphics;
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

            var g = new UITapGestureRecognizer(() => View.EndEditing(true))
            {
                CancelsTouchesInView = false
            };
            View.AddGestureRecognizer(g);
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
                if (!AreAllFieldsValid())
                {
                    segOnOff.SelectedSegment = 0;
                }
                else
                {
                    SaveSettings();
                    SetHubConfiguration();
                    await _locationManager.StartLocationUpdatesAsync(TimeSpan.FromSeconds(5), 10, false);
                }
            }
        }

        private bool AreAllFieldsValid()
        {
            var fieldsToValidate = new List<UITextField>()
            {
                txtHubName,
                txtDeviceId,
                txtAccessKey
            };

            var validationResults = fieldsToValidate.Select(ValidateField).ToList();

            return validationResults.All(b => b);
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

        private bool ValidateField(UITextField textField)
        {
            if (textField.Text.Length > 0)
            {
                ResetField(textField);
                return true;
            }

            HiglightField(textField);
            return false;
        }

        private void HiglightField(UIView textField)
        {
            SetField(textField, UIColor.White, UIColor.Red, 2, 5);
        }

        private void ResetField(UIView textField)
        {
            SetField(textField, UIColor.White, UIColor.Black, 0, 0);
        }
        
        private void SetField(UIView field, UIColor backgroundColour, UIColor borderColour,nfloat borderWidth, nfloat cornerRadius)
        {
            if (field == null)
                return;

            // need to update on the main thread to change the border color
            InvokeOnMainThread(() => {
                field.BackgroundColor = backgroundColour;
                field.Layer.BorderColor = borderColour.CGColor;
                field.Layer.BorderWidth = borderWidth;
                field.Layer.CornerRadius = cornerRadius;
            });

        }
    }
}