using Foundation;
using System;
using MobileTelemetry.Abstractions;
using UIKit;

namespace MobileTelemetry.iOS
{
    public partial class ConfigurationViewController : UIViewController
    {
        private readonly IPositionManager _positionManager;

        public ConfigurationViewController (IntPtr handle) : base (handle)
        {
            _positionManager = SingletonPositionManager.Instance;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            switchEnable.TouchUpInside += SwitchEnable_TouchUpInside;
        }

        private async void SwitchEnable_TouchUpInside(object sender, EventArgs e)
        {
            if (switchEnable.On)
                await _positionManager.StartLocationUpdatesAsync(TimeSpan.FromSeconds(3), 5, true);
            else if (_positionManager.IsListening)
                await _positionManager.StopLocationUpdatesAsync();
        }
    }
}