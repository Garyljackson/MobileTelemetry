using System;
using MobileTelemetry.Abstractions;
using MobileTelemetry.Models;

namespace MobileTelemetry.Iot
{
    public class TripPositionPublisherSource
    {
        private readonly IPositionManager _positionManager;
        private readonly ITripPositionPublisher _tripPositionPublisher;

        public TripPositionPublisherSource(IPositionManager positionManager, ITripPositionPublisher tripPositionPublisher)
        {
            _positionManager = positionManager;
            _tripPositionPublisher = tripPositionPublisher;
            _positionManager.PositionUpdated += PositionManagerPositionUpdated;
        }

        private async void PositionManagerPositionUpdated(object sender, PositionUpdatedEventArgs e)
        {
            var tripPosition = new TripPosition
            {
                Id = Guid.NewGuid(),
                Position = e.Position
            };

            await _tripPositionPublisher.Publish(tripPosition);
        }
    }
}