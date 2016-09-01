using System;
using MobileTelemetry.Abstractions;
using UIKit;

namespace MobileTelemetry.iOS
{
    public partial class SettingsViewController : UIViewController
    {
        private readonly IPositionManager _positionManager;

        public SettingsViewController(IntPtr handle) : base(handle)
        {
            _positionManager = SingletonPositionManager.Instance;
        }

        public override void ViewDidLoad()
        {
            base.ViewDidLoad();
            segOnOff.ValueChanged += SegOnOff_ValueChanged;
        }

        private async void SegOnOff_ValueChanged(object sender, EventArgs e)
        {
            if (segOnOff.SelectedSegment == 0)
            {
                await _positionManager.StopLocationUpdatesAsync();
            }
            else if (segOnOff.SelectedSegment == 1)
            {
                await _positionManager.StartLocationUpdatesAsync(TimeSpan.FromSeconds(3), 5, false);
            }
        }
    }
}