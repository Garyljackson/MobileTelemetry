using System;
using MobileTelemetry.EventSenders;
using MobileTelemetry.Location;
using MobileTelemetry.Models;

namespace MobileTelemetry.EventRouter
{
    public class LocationEventRouter
    {
        private IEventSender<TripLocation> _eventSender;

        public LocationEventRouter(ILocationManager locationManager)
        {
            locationManager.LocationUpdated += PositionManagerOnPositionUpdated;
        }

        public void SetEventSender(IEventSender<TripLocation> eventSender)
        {
            _eventSender = eventSender;
        }

        private async void PositionManagerOnPositionUpdated(object sender, LocationUpdatedEventArgs e)
        {
            if (_eventSender == null)
                return;

            var tripPosition = new TripLocation
            {
                Id = Guid.NewGuid(),
                Location = e.Location
            };

            await _eventSender.SendEvent(tripPosition);
        }

    }
}