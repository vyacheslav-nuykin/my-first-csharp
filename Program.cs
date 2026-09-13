using MyFirstCsharp.Endpoints;
using MyFirstCsharp.Services;

var builder = WebApplication.CreateBuilder(args);

// --- DI ---
builder.Services.AddHttpClient<IWeatherService, OpenMeteoService>();

// --- Swagger ---
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// --- HTTP pipeline ---
if (app.Environment.IsDevelopment())
{
    app.UseSwagger(options =>
    {
        options.SerializeAsV2 = true;
    });
    app.UseSwaggerUI();
}

// --- Routes ---
app.MapGet("/", () => Results.Ok(new { service = "Weather Hub", status = "alive" }));

WeatherEndpoints.Map(app);

app.Logger.LogInformation("Weather Hub is starting...");

app.Run();