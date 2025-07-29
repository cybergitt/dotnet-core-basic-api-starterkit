using BAS.API.Features.Tasks.Mapping;
using BAS.API.Features.Tasks.Responses;
using BAS.Application.Common.Constants;
using BAS.Application.Common.Errors;
using BAS.Application.Common.Result;
using BAS.Application.Interfaces;
using BAS.Infrastructure.Persistence.Repositories;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;

namespace BAS.API.Features.Tasks.Create
{
    public sealed record CreateTaskRequest
    (
        string Description,
        bool IsComplete
    );

    public class CreateTaskEndpoint : IEndpoint
    {
        public void MapEndpoint(WebApplication app)
        {
            app.MapPost("/api/v1/tasks", Handle)
            .WithName("CreateTask")
            .WithOpenApi();
        }

        private static async Task<Result<TaskResponse>> Handle(
        [FromBody] CreateTaskRequest request,
        IValidator<CreateTaskRequest> validator,
        ITodoTaskRepository todoTaskRepository,
        ILogger<CreateTaskEndpoint> logger,
        CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                //return Results.ValidationProblem(validationResult.ToDictionary());
                logger.LogError($"Validation errors");
            }

            var dataAlreadyExists = await todoTaskRepository.GetByDescAsync(request.Description, cancellationToken);

            if (dataAlreadyExists != null)
            {
                logger.LogError($"Data {request.Description} is already exists");
                return Result<TaskResponse>.Failure(ApiErrors.Conflict, 422);
            }

            var data = request.MapToEntity();
            var createdData = await todoTaskRepository.AddAsync(data, cancellationToken);
            logger.LogDebug("Created data: {@createdData}", createdData);

            var response = createdData.MapToResponse();
            //return Results.Ok(response);
            return Result<TaskResponse>.Success(response);
        }
    }
}
