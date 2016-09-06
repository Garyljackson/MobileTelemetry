using System;
using CoreGraphics;
using CoreLocation;
using MapKit;

namespace MobileTelemetry.iOS.Views.Maps
{
    public class TripMapView : MKMapView
    {
        public TripMapView(IntPtr handle) : base(handle)
        { }

        public TripMapView(CGRect mainScreenBounds):base(mainScreenBounds)
        { }

        public void DrawRoute(CLLocationCoordinate2D[] route)
        {
            AddOverlay(MKPolyline.FromCoordinates(route));
        }

    }
}
