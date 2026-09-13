# 🌤️ Weather Hub

A small, well-structured weather microservice built with C# and ASP.NET Core 8.
Fetches real-time weather from the [Open-Meteo](https://open-meteo.com/) API — no API key required.

> "Build systems that outlive you."

## ✅ Features

- **GET `/api/v1/weather/current`** — current weather for any coordinates
- **GET `/`** — simple health probe
- Clean, modular structure (`Models`, `Services`, `Endpoints`)
- Uses `IHttpClientFactory` for proper HTTP lifecycle management
- Interactive Swagger UI in development mode
- Built on **Minimal API** — no controllers, no ceremony

## 📥 Endpoints

| Endpoint | Method | Description |
|---|---|---|
| `/` | GET | Returns `{ "service": "Weather Hub", "status": "alive" }` |
| `/api/v1/weather/current?lat=..&lon=..` | GET | Current weather for given coordinates |
| `/swagger` | GET | Interactive API documentation (dev only) |

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

## 🛠️ Run Locally

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Steps

```bash
# Clone the repo
git clone https://github.com/vyacheslav-nuykin/MyFirstCsharp.git
cd MyFirstCsharp

# Run the server
dotnet run
```

The server starts on `http://localhost:5183` (the exact port is shown in the console).
Open Swagger UI in your browser or try the API directly:

```bash
curl "http://localhost:5183/api/v1/weather/current?lat=59.91&lon=10.75"
```

## 📁 Project Structure

```
MyFirstCsharp/
├── Program.cs                     # Entry point, DI setup
├── Endpoints/
│   └── WeatherEndpoints.cs        # HTTP routes (Minimal API)
├── Models/
│   ├── WeatherResponse.cs         # Public DTO for our API
│   └── OpenMeteoResponse.cs       # Internal DTO for Open-Meteo
├── Services/
│   ├── IWeatherService.cs         # Service contract
│   └── OpenMeteoService.cs        # HTTP client to Open-Meteo
├── Properties/
│   └── launchSettings.json        # Run profiles
├── appsettings.json               # App configuration
└── MyFirstCsharp.http             # Quick HTTP requests for testing
```

## 💡 Why This Project?

- **Learn C#**: practice with `record`, DI, `HttpClient`, Minimal API
- **Real integration**: not a fake `TODO` list — talks to a real external service
- **No API keys**: Open-Meteo is free and open, so anyone can clone and run
- **Minimal**: no unnecessary dependencies, no layers for the sake of layers

## 🌟 Future Ideas

- Add caching (Redis) for frequently requested coordinates
- Add `history` endpoint backed by PostgreSQL
- Add xUnit tests + GitHub Actions CI
- Add Prometheus metrics for observability

## 🙏 Thanks & Feedback

Created by [Вячеслав Нуйкин](https://github.com/vyacheslav-nuykin) — self-taught software engineer focused on backend development and scalable systems.

Feel free to fork, star, or submit issues!

## 📄 License

This project is licensed under the MIT License — see the [LICENSE.txt](LICENSE.txt) file for details.