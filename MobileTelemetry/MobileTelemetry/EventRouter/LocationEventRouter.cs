using System;
using MobileTelemetry.EventSenders;
using MobileTelemetry.Location;
using MobileTelemetry.Models;

namespace MobileTelemetry.EventRouter
{
    public class LocationEventRouter
    {
        private static IEventSender<TripLocation> _eventSender;
        private static readonly ILocationManager LocationManager;

        private static readonly Lazy<LocationEventRouter> InternalInstance = new Lazy<LocationEventRouter>(() => new LocationEventRouter());

        static LocationEventRouter()
        {
            LocationManager = Location.LocationManager.Instance;
            LocationManager.LocationUpdated += LocationManager_LocationUpdated;
        }

        public static LocationEventRouter Instance => InternalInstance.Value;

        private static async void LocationManager_LocationUpdated(object sender, LocationUpdatedEventArgs e)
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

        public void SetEventSender(IEventSender<TripLocation> eventSender)
        {
            _eventSender = eventSender;
        }


    }
}