using System;
using CoreLocation;
using MapKit;
using MobileTelemetry.Location;
using UIKit;

namespace MobileTelemetry.iOS
{
    public partial class MapViewController : UIViewController
    {
        private readonly ILocationManager _locationManager;
        private MKMapView _mkMapView;
        private Models.Location _lastLocation;
        private readonly MapDelegate _mapDelegate;

        public MapViewController (IntPtr handle) : base (handle)
        {
            _locationManager = LocationManager.Instance;
            _mapDelegate = new MapDelegate();
        }

        private void LocationManagerOnLocationUpdated(object sender, Models.LocationUpdatedEventArgs e)
        {
            if (_lastLocation == null)
            {
                _lastLocation = e.Location;
                return;
            }

            var overlay = MKPolyline.FromCoordinates(
                new[]
                {
                    new CLLocationCoordinate2D(_lastLocation.Latitude, _lastLocation.Longitude),
                    new CLLocationCoordinate2D(e.Location.Latitude, e.Location.Longitude)
                });

            _mkMapView.AddOverlay(overlay);

            _lastLocation = e.Location;
        }

        public override void LoadView()
        {
            _mkMapView = new MKMapView(UIScreen.MainScreen.Bounds)
            {
                ShowsUserLocation = true,
                MapType = MKMapType.Standard,
                ZoomEnabled = true,
                ScrollEnabled = true,
                Delegate = _mapDelegate
            };

            View = _mkMapView;
        }


        public override void ViewDidLoad()
        {
            _locationManager.LocationUpdated += LocationManagerOnLocationUpdated;
        }

        public override void ViewDidUnload()
        {
            _locationManager.LocationUpdated -= LocationManagerOnLocationUpdated;
        }

        private static double KilometresToLatitudeDegrees(double kms)
        {
            const double earthRadius = 6371.0; // in kms
            const double radiansToDegrees = 180.0 / Math.PI;
            return (kms / earthRadius) * radiansToDegrees;
        }

        private static double KilometresToLongitudeDegrees(double kms, double atLatitude)
        {
            const double earthRadius = 6371.0; // in kms
            const double degreesToRadians = Math.PI / 180.0;
            const double radiansToDegrees = 180.0 / Math.PI;

            // derive the earth's radius at that point in latitude
            var radiusAtLatitude = earthRadius * Math.Cos(atLatitude * degreesToRadians);
            return (kms / radiusAtLatitude) * radiansToDegrees;
        }

        private class MapDelegate : MKMapViewDelegate
        {
            public override void DidUpdateUserLocation(MKMapView mapView, MKUserLocation userLocation)
            {
                if (mapView.UserLocation != null)
                {
                    var coords = mapView.UserLocation.Coordinate;
                    var span = new MKCoordinateSpan(KilometresToLatitudeDegrees(2), KilometresToLongitudeDegrees(2, coords.Latitude));
                    mapView.Region = new MKCoordinateRegion(coords, span);
                }
            }

            public override MKOverlayView GetViewForOverlay(MKMapView mapView, IMKOverlay overlay)
            {
                var polygon = overlay as MKPolyline;

                var polygonView = new MKPolylineView(polygon)
                {
                    LineWidth = 3.0f,
                    StrokeColor = UIColor.Red
                };
                return polygonView;

                
            }
        }

    }
}