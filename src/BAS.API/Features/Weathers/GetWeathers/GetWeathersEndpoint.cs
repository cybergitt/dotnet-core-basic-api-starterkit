using BAS.Application.Interfaces;

namespace BAS.API.Features.Weathers.GetWeathers
{
    public class GetWeathersEndpoint : IEndpoint
    {
        public void MapEndpoint(WebApplication app)
        {
            app.MapGet("/api/v1/weathers", async (CancellationToken cancellationToken) =>
            {
                var handler = new GetWeathersHandler();
                var result = await handler.Handle(cancellationToken);
                return Results.Ok(result);
            })
            .WithName("GetWeathers")
            .WithOpenApi();
        }
    }
}
