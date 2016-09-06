using System;
using CoreLocation;
using MapKit;
using MobileTelemetry.iOS.Views.Maps;
using MobileTelemetry.Location;
using UIKit;

namespace MobileTelemetry.iOS
{
    public partial class MapViewController : UIViewController
    {
        private readonly ILocationManager _locationManager;
        private Models.Location _lastLocation;

        private TripMapView _tripMapView;
        private readonly TripMapViewDelegate _tripMapViewDelegate;

        public MapViewController (IntPtr handle) : base (handle)
        {
            _locationManager = LocationManager.Instance;
            _tripMapViewDelegate = new TripMapViewDelegate();
        }

        private void LocationManagerOnLocationUpdated(object sender, Models.LocationUpdatedEventArgs e)
        {
            if (_lastLocation == null)
            {
                _lastLocation = e.Location;
                return;
            }

            var coordinates = new[]
            {
                new CLLocationCoordinate2D(_lastLocation.Latitude, _lastLocation.Longitude),
                new CLLocationCoordinate2D(e.Location.Latitude, e.Location.Longitude)
            };

            _tripMapView.DrawRoute(coordinates);

            _lastLocation = e.Location;
        }

        public override void LoadView()
        {
            _tripMapView = new TripMapView(UIScreen.MainScreen.Bounds)
            {
                ShowsUserLocation = true,
                MapType = MKMapType.Standard,
                ZoomEnabled = true,
                ScrollEnabled = true,
                Delegate = _tripMapViewDelegate
            };

            View = _tripMapView;
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