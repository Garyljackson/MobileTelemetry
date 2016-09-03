using System;
using MobileTelemetry.Abstractions;
using MobileTelemetry.EventSenders;
using MobileTelemetry.Models;

namespace MobileTelemetry.EventPublishers
{
    public class PositionEventPublisher
    {
        private IEventSender<TripPosition> _eventSender;

        public PositionEventPublisher(ILocationManager locationManager)
        {
            locationManager.PositionUpdated += PositionManagerOnPositionUpdated;
        }

        public void SetEventSender(IEventSender<TripPosition> eventSender)
        {
            _eventSender = eventSender;
        }

        private async void PositionManagerOnPositionUpdated(object sender, PositionUpdatedEventArgs e)
        {
            if (_eventSender == null)
                return;

            var tripPosition = new TripPosition
            {
                Id = Guid.NewGuid(),
                Position = e.Position
            };

            await _eventSender.SendEvent(tripPosition);
        }

    }
}