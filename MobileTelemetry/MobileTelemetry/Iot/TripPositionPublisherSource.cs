using System;
using MobileTelemetry.Abstractions;
using MobileTelemetry.Models;

namespace MobileTelemetry.Iot
{
    public class TripPositionPublisherSource
    {
        private readonly IPositionManager _positionManager;

        public TripPositionPublisherSource(IPositionManager positionManager)
        {
            _positionManager = positionManager;
            _positionManager.PositionUpdated += PositionManagerPositionUpdated;
        }

        public ITripPositionPublisher TripPositionPublisher { get; set; }

        private async void PositionManagerPositionUpdated(object sender, PositionUpdatedEventArgs e)
        {
            if (TripPositionPublisher == null)
            {
                return;
            }

            var tripPosition = new TripPosition
            {
                Id = Guid.NewGuid(),
                Position = e.Position
            };

            await TripPositionPublisher.Publish(tripPosition);
        }
    }
}