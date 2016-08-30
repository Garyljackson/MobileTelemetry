// WARNING
//
// This file has been generated automatically by Xamarin Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace MobileTelemetry.iOS
{
    [Register ("DetailsViewController")]
    partial class DetailsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtAccuracy { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtAltitude { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtAltitudeAccuracy { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtHeading { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtLatitude { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtLongitude { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtSpeed { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtTimestamp { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (txtAccuracy != null) {
                txtAccuracy.Dispose ();
                txtAccuracy = null;
            }

            if (txtAltitude != null) {
                txtAltitude.Dispose ();
                txtAltitude = null;
            }

            if (txtAltitudeAccuracy != null) {
                txtAltitudeAccuracy.Dispose ();
                txtAltitudeAccuracy = null;
            }

            if (txtHeading != null) {
                txtHeading.Dispose ();
                txtHeading = null;
            }

            if (txtLatitude != null) {
                txtLatitude.Dispose ();
                txtLatitude = null;
            }

            if (txtLongitude != null) {
                txtLongitude.Dispose ();
                txtLongitude = null;
            }

            if (txtSpeed != null) {
                txtSpeed.Dispose ();
                txtSpeed = null;
            }

            if (txtTimestamp != null) {
                txtTimestamp.Dispose ();
                txtTimestamp = null;
            }
        }
    }
}