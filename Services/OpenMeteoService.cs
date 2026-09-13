using System.Net.Http.Json;
using MyFirstCsharp.Models;

namespace MyFirstCsharp.Services
{
    /// <summary>
    /// Implementation of IWeatherService using the Open-Meteo API.
    /// </summary>
    public sealed class OpenMeteoService : IWeatherService
    {
        private const string BaseUrl = "https://api.open-meteo.com/v1/forecast";

        private readonly HttpClient _httpClient;
        private readonly ILogger<OpenMeteoService> _logger;

        public OpenMeteoService(
            HttpClient httpClient,
            ILogger<OpenMeteoService> logger)
        {
            _httpClient = httpClient;
            _logger = logger;
        }

        public async Task<WeatherResponse> GetCurrentWeatherAsync(
            double latitude,
            double longitude,
            CancellationToken cancellationToken = default)
        {
            var url = $"{BaseUrl}?latitude={latitude}&longitude={longitude}" +
                      "&current=temperature_2m,relative_humidity_2m,wind_speed_10m";

            _logger.LogInformation(
                "Fetching weather from Open-Meteo: lat={Lat}, lon={Lon}",
                latitude, longitude);

            var external = await _httpClient.GetFromJsonAsync<OpenMeteoResponse>(
                url, cancellationToken);

            if (external is null)
            {
                _logger.LogWarning("Open-Meteo returned empty response");
                throw new InvalidOperationException(
                    "Failed to fetch weather from Open-Meteo");
            }

            return new WeatherResponse(
                Latitude: external.Latitude,
                Longitude: external.Longitude,
                TemperatureCelsius: external.Current.TemperatureCelsius,
                WindSpeedKmh: external.Current.WindSpeedKmh,
                HumidityPercent: external.Current.HumidityPercent,
                ObservedAt: new DateTimeOffset(
                    DateTime.SpecifyKind(
                        external.Current.Time,
                        DateTimeKind.Utc)));
        }
    }
}