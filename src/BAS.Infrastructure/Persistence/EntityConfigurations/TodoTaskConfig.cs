using BAS.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BAS.Infrastructure.Persistence.EntityConfigurations
{
    public class TodoTaskConfig : IEntityTypeConfiguration<TodoTask>
    {
        public void Configure(EntityTypeBuilder<TodoTask> builder)
        {
            builder.HasKey(e => e.TaskId);

            builder.ToTable("tasks");

            builder.Property(e => e.TaskId)
                .HasColumnName("id");

            builder.Property(e => e.Description)
                .HasMaxLength(255)
                .IsUnicode(false)
                .HasColumnName("description");

            builder.Property(e => e.Completed)
                .HasColumnName("completed");

            builder.Property(e => e.CreatedAt)
                .HasColumnType("datetime2")
                .HasColumnName("created_at");
        }
    }
}
