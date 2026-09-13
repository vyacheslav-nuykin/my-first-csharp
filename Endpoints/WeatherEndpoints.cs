using MyFirstCsharp.Services;

namespace MyFirstCsharp.Endpoints
{
    /// <summary>
    /// Provides API endpoints for retrieving current weather data by coordinates.
    /// </summary>
    public static class WeatherEndpoints
    {
        public static void Map(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("/api/v1/weather");

            group.MapGet("/current", GetCurrentWeather)
                 .WithName("GetCurrentWeather")
                 .WithSummary("Returns the current weather based on coordinates.");
        }

        private static async Task<IResult> GetCurrentWeather(
            double lat,
            double lon,
            IWeatherService weatherService,
            CancellationToken cancellationToken)
        {
            var weather = await weatherService.GetCurrentWeatherAsync(
                lat, lon, cancellationToken);

            return Results.Ok(weather);
        }
    }
}