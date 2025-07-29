using BAS.Domain.Entities;

namespace BAS.Infrastructure.Persistence.Repositories
{
    public interface ITodoTaskRepository : IBaseRepository<TodoTask>
    {
        Task<TodoTask?> GetByIdAsync(long id, CancellationToken cancellationToken = default);
        Task<IEnumerable<TodoTask>> GetByListIdAsync(IList<long> listId, CancellationToken cancellationToken = default);
        Task<TodoTask?> GetByDescAsync(string desc, CancellationToken cancellationToken = default);
        Task<IEnumerable<TodoTask>> GetByDescLikeAsync(string desc, CancellationToken cancellationToken = default);
    }
}
