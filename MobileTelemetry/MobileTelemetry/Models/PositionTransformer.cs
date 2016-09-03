namespace MobileTelemetry.Models
{
    public static class PositionTransformer
    {
        public static Position Transform(this Plugin.Geolocator.Abstractions.Position position)
        {
            var result = new Position
            {
                Accuracy = position.Accuracy,
                Altitude = position.Altitude,
                AltitudeAccuracy = position.AltitudeAccuracy,
                Heading = position.Heading,
                Latitude = position.Latitude,
                Longitude = position.Longitude,
                Speed = position.Speed,
                Timestamp = position.Timestamp.ToLocalTime()
            };

            return result;
        }
    }
}