using System.Text.Json.Serialization;

namespace MyFirstCsharp.Models
{
    /// <summary>
    /// DTO response from the Open-Meteo API.
    /// </summary>
    internal sealed class OpenMeteoResponse
    {
        [JsonPropertyName("latitude")]
        public double Latitude { get; init; }

        [JsonPropertyName("longitude")]
        public double Longitude { get; init; }

        [JsonPropertyName("current")]
        public CurrentData Current { get; init; } = new();

        internal sealed class CurrentData
        {
            [JsonPropertyName("time")]
            public DateTime Time { get; init; }

            [JsonPropertyName("temperature_2m")]
            public double TemperatureCelsius { get; init; }

            [JsonPropertyName("relative_humidity_2m")]
            public int HumidityPercent { get; init; }

            [JsonPropertyName("wind_speed_10m")]
            public double WindSpeedKmh { get; init; }
        }
    }
}