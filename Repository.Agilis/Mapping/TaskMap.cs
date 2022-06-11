using Domain.Agilis.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Agilis.Mapping
{
    public class TaskMap : IEntityTypeConfiguration<TaskEntity>
    {
        public void Configure(EntityTypeBuilder<TaskEntity> builder)
        {
            builder.ToTable("Task");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.StartDate);
            builder.Property(x => x.EndDate);
            builder.Property(x => x.ReleaseDate);
            builder.Property(x => x.Active).IsRequired();
            builder.HasOne(x => x.Sprint).WithMany(x => x.Tasks).HasForeignKey(x => x.IdSprint);
            builder.HasOne(x => x.Member).WithMany(x => x.Tasks).HasForeignKey(x => x.IdMember);
        }
    }
}
