using Foundation;
using System;
using CoreLocation;
using MapKit;
using MobileTelemetry.Location;
using UIKit;

namespace MobileTelemetry.iOS
{
    public partial class MapViewController : UIViewController
    {
        private MKMapView _map;
        private readonly ILocationManager _locationManager;

        public MapViewController (IntPtr handle) : base (handle)
        {
            _locationManager = SingletonLocationManager.Instance;

        }

        private void LocationManagerOnLocationUpdated(object sender, Models.LocationUpdatedEventArgs e)
        {
            _map.AddAnnotations(new MKPointAnnotation
            {
                Coordinate = new CLLocationCoordinate2D(e.Location.Latitude, e.Location.Longitude)
            });
        }

        public override void LoadView()
        {
            _map = new MKMapView(UIScreen.MainScreen.Bounds)
            {
                ShowsUserLocation = true,
                MapType = MKMapType.Standard,
                ZoomEnabled = true,
                ScrollEnabled = true
            };

            View = _map;
        }

        
        public override void ViewDidLoad()
        {
            _locationManager.LocationUpdated += LocationManagerOnLocationUpdated;
        }

        public override void ViewDidUnload()
        {
            _locationManager.LocationUpdated -= LocationManagerOnLocationUpdated;
        }


    }
}