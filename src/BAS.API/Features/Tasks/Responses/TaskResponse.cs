namespace BAS.API.Features.Tasks.Responses
{
    public sealed record TaskResponse
    (
        long Id,
        string? Description,
        bool IsComplete,
        DateTime? CreatedAt
    );
}
