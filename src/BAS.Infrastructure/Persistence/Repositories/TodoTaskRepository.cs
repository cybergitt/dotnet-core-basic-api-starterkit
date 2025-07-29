using BAS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BAS.Infrastructure.Persistence.Repositories
{
    public class TodoTaskRepository : BaseRepository<TodoTask>, ITodoTaskRepository
    {
        public readonly ApplicationDbContext _dbContext;

        public TodoTaskRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<TodoTask?> GetByIdAsync(long id, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<TodoTask>()
                .AsNoTracking()
                .Where(x => x.Id == id)
                .SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<TodoTask>> GetByListIdAsync(IList<long> listId, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<TodoTask>()
                .AsNoTracking()
                .Where(x => listId.Contains(x.Id))
                .ToListAsync(cancellationToken);
        }

        public async Task<TodoTask?> GetByDescAsync(string desc, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<TodoTask>()
                .AsNoTracking()
                .Where(x => x.Description.ToLower() == desc.ToLower())
                .SingleOrDefaultAsync(cancellationToken);
        }

        public async Task<IEnumerable<TodoTask>> GetByDescLikeAsync(string desc, CancellationToken cancellationToken = default)
        {
            return await _dbContext.Set<TodoTask>()
                .AsNoTracking()
                .Where(x => x.Description.Contains(desc))
                .ToListAsync(cancellationToken);
        }
    }
}
