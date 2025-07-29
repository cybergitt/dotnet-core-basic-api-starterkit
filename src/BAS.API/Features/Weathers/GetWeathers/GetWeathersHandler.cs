using BAS.API.Features.Weathers.Responses;

namespace BAS.API.Features.Weathers.GetWeathers
{
    public class GetWeathersHandler
    {
        public GetWeathersHandler()
        {
        }

        public async Task<IEnumerable<GetWeatherResponse>> Handle(CancellationToken cancellationToken)
        {
            // Simulate fetching weather data
            await Task.Delay(1000, cancellationToken); // Simulating async operation
            var summaries = new[]
            {
                "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
            };
            var forecast = Enumerable.Range(1, 5).Select(index =>
                new GetWeatherResponse
                (
                    DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                    Random.Shared.Next(-20, 55),
                    summaries[Random.Shared.Next(summaries.Length)]
                ));
            return await Task.FromResult(forecast);

        }
    }
}
