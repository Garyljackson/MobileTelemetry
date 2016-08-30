using System;
using MobileTelemetry.Abstractions;
using MobileTelemetry.Models;

namespace MobileTelemetry.Services
{
    public class PositionPublisher : IPositionPublisher
    {
        private readonly IPositionManager _positionManager;
        private readonly IHub _hub;

        public PositionPublisher(IPositionManager positionManager, IHub hub)
        {
            _positionManager = positionManager;
            _hub = hub;

            ConfigureEvent();
        }


        private void ConfigureEvent()
        {
            _positionManager.PositionUpdated += PositionManagerPositionUpdated;
        }

        private void PositionManagerPositionUpdated(object sender, PositionUpdatedEventArgs e)
        {
            var tripPosition = new TripPosition()
            {
                Id = Guid.NewGuid(),
                Position = e.Position
            };

            _hub.SendEvent(tripPosition);
        }
    }
}