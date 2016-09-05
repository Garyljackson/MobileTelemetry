using Foundation;
using System;
using System.Globalization;
using MobileTelemetry.Location;
using UIKit;

namespace MobileTelemetry.iOS
{
    public partial class RealtimeViewController : UIViewController
    {
        private readonly ILocationManager _locationManager;

        public RealtimeViewController (IntPtr handle) : base (handle)
        {
            _locationManager = LocationManager.Instance;
        }

        private void LocationManagerOnLocationUpdated(object sender, Models.LocationUpdatedEventArgs e)
        {
            var position = e.Location;
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
            _locationManager.LocationUpdated += LocationManagerOnLocationUpdated;
        }

        public override void ViewDidUnload()
        {
            _locationManager.LocationUpdated -= LocationManagerOnLocationUpdated;
        }
    }
}