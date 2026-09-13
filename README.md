# my-first-csharp

A weather microservice on ASP.NET Core 8 Minimal API. Fetches real-time weather
from [Open-Meteo](https://open-meteo.com/) — no API key required.

Built as my first C# project to practice `record`, dependency injection,
`IHttpClientFactory`, and Minimal API.

## Endpoints

| Endpoint | Method | Description |
|---|---|---|
| `/` | GET | Health probe: `{"service":"Weather Hub","status":"alive"}` |
| `/api/v1/weather/current?lat=..&lon=..` | GET | Current weather for given coordinates |
| `/swagger` | GET | Swagger UI (development only) |

### Example response

```json
{
  "latitude": 59.906296,
  "longitude": 10.744095,
  "temperatureCelsius": 17.3,
  "windSpeedKmh": 11.5,
  "humidityPercent": 40,
  "observedAt": "2026-09-13T12:15:00+00:00",
  "temperatureFahrenheit": 63.1
}
```

## Run locally

Requires [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0).

```bash
git clone https://github.com/vyacheslav-nuykin/my-first-csharp.git
cd my-first-csharp
dotnet run
```

The server starts on `http://localhost:5183` (exact port is printed in the console).

```bash
curl "http://localhost:5183/api/v1/weather/current?lat=59.91&lon=10.75"
```

## Structure

```
my-first-csharp/
├── Program.cs                     # Entry point, DI setup
├── Endpoints/
│   └── WeatherEndpoints.cs        # HTTP routes (Minimal API)
├── Models/
│   ├── WeatherResponse.cs         # Public DTO
│   └── OpenMeteoResponse.cs       # Internal DTO for Open-Meteo
├── Services/
│   ├── IWeatherService.cs         # Service contract
│   └── OpenMeteoService.cs        # HTTP client to Open-Meteo
├── Properties/
│   └── launchSettings.json
├── appsettings.json
└── my-first-csharp.http           # Quick HTTP requests for testing
```

## Notes

- The public `WeatherResponse` and internal `OpenMeteoResponse` are separate DTOs,
  so changes to the upstream API don't leak into this API's contract.
- `IHttpClientFactory` is used via `AddHttpClient<IWeatherService, OpenMeteoService>()`
  for proper connection pooling.

## License

MIT — see [LICENSE.txt](LICENSE.txt).
