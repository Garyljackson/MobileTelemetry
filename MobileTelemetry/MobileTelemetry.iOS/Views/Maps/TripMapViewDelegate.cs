using System;
using MapKit;
using UIKit;

namespace MobileTelemetry.iOS.Views.Maps
{
    public class TripMapViewDelegate : MKMapViewDelegate
    {
        private const double Alpha = 0.6;
        private readonly UIColor _color = UIColor.Blue;
        private bool _locationZoomed;

        public override MKOverlayRenderer OverlayRenderer(MKMapView mapView, IMKOverlay overlay)
        {
            return new MKPolylineRenderer(overlay as MKPolyline)
            {
                Alpha = (nfloat)Alpha,
                LineWidth = (nfloat)4.0,
                FillColor = _color,
                StrokeColor = _color
            };
        }

        public override void DidUpdateUserLocation(MKMapView mapView, MKUserLocation userLocation)
        {
            if (mapView.UserLocation != null && !_locationZoomed)
            {
                _locationZoomed = true;
                var coords = mapView.UserLocation.Coordinate;
                var span = new MKCoordinateSpan(KilometresToLatitudeDegrees(2), KilometresToLongitudeDegrees(2, coords.Latitude));
                mapView.Region = new MKCoordinateRegion(coords, span);
            }
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

    }
}
