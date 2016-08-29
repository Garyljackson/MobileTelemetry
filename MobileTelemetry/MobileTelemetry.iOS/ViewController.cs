using System;
using System.Globalization;
using UIKit;

namespace MobileTelemetry.iOS
{
    public partial class ViewController : UIViewController
    {
        private static PositionManager _positionManager;

        public ViewController(IntPtr handle) : base(handle)
        {
            _positionManager = PositionManager.Instance;
            _positionManager.PositionUpdated += _positionManager_PositionUpdated;
        }

        private void _positionManager_PositionUpdated(object sender, PositionUpdatedEventArgs e)
        {
            txtLatitude.Text = e.Position.Latitude.ToString(CultureInfo.InvariantCulture);
            txtLongitude.Text = e.Position.Longitude.ToString(CultureInfo.InvariantCulture);
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();


            switchEnable.TouchUpInside += SwitchEnable_TouchUpInside;
        }

        private async void SwitchEnable_TouchUpInside(object sender, EventArgs e)
        {
            if (switchEnable.On)
            {
                await _positionManager.StartLocationUpdates(TimeSpan.FromSeconds(3), 5, true);
            }
            else if (_positionManager.IsListening)
            {
                await _positionManager.StopLocationUpdates();
            }
        }

        public override void DidReceiveMemoryWarning()
        {
            base.DidReceiveMemoryWarning();
            // Release any cached data, images, etc that aren't in use.
        }
    }
}