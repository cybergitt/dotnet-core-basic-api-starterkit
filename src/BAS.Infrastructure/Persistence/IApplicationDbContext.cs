using BAS.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace BAS.Infrastructure.Persistence
{
    public interface IApplicationDbContext : IUnitOfWork
    {
        public DbSet<TodoTask> TodoTasks { get; }
    }
}
