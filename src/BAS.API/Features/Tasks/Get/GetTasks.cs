using BAS.API.Features.Tasks.Mapping;
using BAS.API.Features.Tasks.Responses;
using BAS.Application.Common.Response;
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
            HttpContext context,
            ITodoTaskRepository todoTaskRepository,
            ILogger<GetTasksEndpoint> logger,
            CancellationToken cancellationToken)
        {
            var tasks = await todoTaskRepository.GetAllAsync(cancellationToken);
            logger.LogDebug("Retrieved tasks: {@tasks}", tasks);
            //var response = tasks.Select(task => task.MapToResponse()).ToList();
            //var response = tasks.MapToResponse();
            var response = new SuccessResponse<IEnumerable<TaskResponse>>(tasks.MapToResponse(), context.TraceIdentifier);
            return Results.Ok(response);
        }
    }
}
