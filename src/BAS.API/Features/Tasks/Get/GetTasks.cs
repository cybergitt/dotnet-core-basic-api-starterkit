using BAS.API.Features.Tasks.Mapping;
using BAS.Application.Interfaces;
using BAS.Infrastructure.Persistence.Repositories;

namespace BAS.API.Features.Tasks.Get
{
    public class GetTasksEndpoint : IEndpoint
    {
        public void MapEndpoint(WebApplication app)
        {
            app.MapGet("/api/v1/tasks", Handle)
                .WithName("GetTasks")
                .WithOpenApi();
        }
        private static async Task<IResult> Handle(
            ITodoTaskRepository todoTaskRepository,
            ILogger<GetTasksEndpoint> logger,
            CancellationToken cancellationToken)
        {
            var tasks = await todoTaskRepository.GetAllAsync(cancellationToken);
            logger.LogDebug("Retrieved tasks: {@tasks}", tasks);
            //var response = tasks.Select(task => task.MapToResponse()).ToList();
            var response = tasks.MapToResponse();
            return Results.Ok(response);
        }
    }
}
