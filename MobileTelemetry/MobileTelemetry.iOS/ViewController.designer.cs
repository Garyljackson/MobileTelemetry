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
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UISwitch switchEnable { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtLatitude { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextField txtLongitude { get; set; }

        void ReleaseDesignerOutlets ()
        {
            if (switchEnable != null) {
                switchEnable.Dispose ();
                switchEnable = null;
            }

            if (txtLatitude != null) {
                txtLatitude.Dispose ();
                txtLatitude = null;
            }

            if (txtLongitude != null) {
                txtLongitude.Dispose ();
                txtLongitude = null;
            }
        }
    }
}