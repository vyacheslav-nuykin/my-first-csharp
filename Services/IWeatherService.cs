using MyFirstCsharp.Models;

namespace MyFirstCsharp.Services
{
    /// <summary>
    /// Weather service contract.
    /// </summary>
    public interface IWeatherService
    {
        Task<WeatherResponse> GetCurrentWeatherAsync(
            double latitude,
            double longitude,
            CancellationToken cancellationToken = default);
    }
}