using System;
using MobileTelemetry.Abstractions;
using MobileTelemetry.EventSenders;
using MobileTelemetry.Models;

namespace MobileTelemetry.EventPublishers
{
    public class PositionEventPublisher
    {
        private IEventSender<TripLocation> _eventSender;

        public PositionEventPublisher(ILocationManager locationManager)
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