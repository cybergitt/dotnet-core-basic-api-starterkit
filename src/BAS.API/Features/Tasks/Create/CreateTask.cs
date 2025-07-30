using BAS.API.Extensions;
using BAS.API.Features.Tasks.Mapping;
using BAS.API.Features.Tasks.Responses;
using BAS.Application.Common.Errors;
using BAS.Application.Common.Response;
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

        private static async Task<IResult> Handle(
        HttpContext context,
        [FromBody] CreateTaskRequest request,
        IValidator<CreateTaskRequest> validator,
        ITodoTaskRepository todoTaskRepository,
        ILogger<CreateTaskEndpoint> logger,
        CancellationToken cancellationToken)
        {
            var validationResult = await validator.ValidateAsync(request, cancellationToken);
            if (!validationResult.IsValid)
            {
                return Results.ValidationProblem(validationResult.ToDictionary());
            }

            var dataAlreadyExists = await todoTaskRepository.GetByDescAsync(request.Description, cancellationToken);

            if (dataAlreadyExists != null)
            {
                logger.LogError($"Data {request.Description} is already exists");
                //return Result<TaskResponse>.Failure(ApiErrors.Conflict, 422);
                //return Error.Conflict($"Shipment for order '{request.OrderId}' is already created").ToProblem();
                return Error.Conflict.ToProblem(context);
            }

            var data = request.MapToEntity();
            var createdData = await todoTaskRepository.AddAsync(data, cancellationToken);
            logger.LogDebug("Created data: {@createdData}", createdData);

            //var response = createdData.MapToResponse();
            //return Results.Ok(response);
            //return Result<TaskResponse>.Success(response);
            var response = new SuccessResponse<TaskResponse>(createdData.MapToResponse(), context.TraceIdentifier);
            return Results.Ok(response);
        }
    }
}
