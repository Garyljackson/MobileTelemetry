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
    [Register ("SettingsViewController")]
    partial class SettingsViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblAccessKey { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblDeviceId { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblHubName { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblSettings { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UILabel lblTracking { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISegmentedControl segOnOff { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtAccessKey { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtDeviceId { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtHubName { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (lblAccessKey != null) {
                lblAccessKey.Dispose ();
                lblAccessKey = null;
            }

            if (lblDeviceId != null) {
                lblDeviceId.Dispose ();
                lblDeviceId = null;
            }

            if (lblHubName != null) {
                lblHubName.Dispose ();
                lblHubName = null;
            }

            if (lblSettings != null) {
                lblSettings.Dispose ();
                lblSettings = null;
            }

            if (lblTracking != null) {
                lblTracking.Dispose ();
                lblTracking = null;
            }

            if (segOnOff != null) {
                segOnOff.Dispose ();
                segOnOff = null;
            }

            if (txtAccessKey != null) {
                txtAccessKey.Dispose ();
                txtAccessKey = null;
            }

            if (txtDeviceId != null) {
                txtDeviceId.Dispose ();
                txtDeviceId = null;
            }

            if (txtHubName != null) {
                txtHubName.Dispose ();
                txtHubName = null;
            }
        }
    }
}