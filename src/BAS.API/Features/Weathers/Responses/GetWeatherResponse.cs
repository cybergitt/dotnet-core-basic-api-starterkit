namespace BAS.API.Features.Weathers.Responses
{
    public sealed record GetWeatherResponse(DateOnly? Date, int? TemperatureC, string? Summary);
}
