using BAS.API.Features.Tasks.Create;
using BAS.API.Features.Tasks.Responses;
using BAS.Domain.Entities;

namespace BAS.API.Features.Tasks.Mapping
{
    public static class CreateTaskMappingExtensions
    {
        public static TodoTask MapToEntity(this CreateTaskRequest request)
            => new()
            {
                Description = request.Description,
                Completed = request.IsComplete,
                CreatedAt = DateTime.Now
            };

        public static TaskResponse MapToResponse(this TodoTask source)
            => new(
                source.Id,
                source.Description,
                source.Completed,
                source.CreatedAt
                );

        public static IEnumerable<TaskResponse> MapToResponse(this IEnumerable<TodoTask> sources) =>
            sources.Select(source => source.MapToResponse());
    }
}
