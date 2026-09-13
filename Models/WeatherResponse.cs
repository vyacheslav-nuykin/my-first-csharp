namespace MyFirstCsharp.Models
{
    /// <summary>
    /// Weather at a specific location and time.
    /// </summary>
    /// <param name="Latitude">Latitude, from -90 to 90.</param>
    /// <param name="Longitude">Longitude, from -180 to 180.</param>
    /// <param name="TemperatureCelsius">Temperature in °C.</param>
    /// <param name="WindSpeedKmh">Wind speed in km/h.</param>
    /// <param name="HumidityPercent">Relative humidity, 0-100.</param>
    /// <param name="ObservedAt">Observation time in UTC.</param>
    public sealed record WeatherResponse(
        double Latitude,
        double Longitude,
        double TemperatureCelsius,
        double WindSpeedKmh,
        int HumidityPercent,
        DateTimeOffset ObservedAt)
    {
        public double TemperatureFahrenheit =>
            Math.Round(TemperatureCelsius * 9 / 5 + 32, 1);
    }
}
