using Foundation;
using System;
using System.Globalization;
using MobileTelemetry.Abstractions;
using UIKit;

namespace MobileTelemetry.iOS
{
    public partial class RealtimeViewController : UIViewController
    {
        private readonly IPositionManager _positionManager;

        public RealtimeViewController (IntPtr handle) : base (handle)
        {
            _positionManager = SingletonPositionManager.Instance;
        }

        private void PositionManagerOnPositionUpdated(object sender, Models.PositionUpdatedEventArgs e)
        {
            var position = e.Position;
            txtTimestamp.Text = position.Timestamp.ToLocalTime().ToString("s");
            txtLatitude.Text = position.Latitude.ToString(CultureInfo.InvariantCulture);
            txtLongitude.Text = position.Longitude.ToString(CultureInfo.InvariantCulture);
            txtAltitude.Text = position.Altitude.ToString(CultureInfo.InvariantCulture);
            txtAccuracy.Text = position.Accuracy.ToString(CultureInfo.InvariantCulture);
            txtAltitudeAccuracy.Text = position.AltitudeAccuracy.ToString(CultureInfo.InvariantCulture);
            txtSpeed.Text = position.Speed.ToString(CultureInfo.InvariantCulture);
        }


        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            _positionManager.PositionUpdated += PositionManagerOnPositionUpdated;
        }

        public override void ViewDidUnload()
        {
            _positionManager.PositionUpdated -= PositionManagerOnPositionUpdated;
        }
    }
}