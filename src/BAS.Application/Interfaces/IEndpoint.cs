using Microsoft.AspNetCore.Builder;

namespace BAS.Application.Interfaces
{
    public interface IEndpoint
    {
        void MapEndpoint(WebApplication app);
    }
}
