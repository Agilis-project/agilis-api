using Domain.Agilis.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Agilis.Mapping
{
    public class SprintMap : IEntityTypeConfiguration<SprintEntity>
    {
        public void Configure(EntityTypeBuilder<SprintEntity> builder)
        {
            builder.ToTable("Sprint");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Name).IsRequired();
            builder.Property(x => x.StartDate);
            builder.Property(x => x.EndDate);
            builder.Property(x => x.SprintNumber);
            builder.Property(x => x.Active).IsRequired();
            builder.HasOne(x => x.Project).WithMany(x => x.Sptints).HasForeignKey(x => x.IdProject);
        }
    }
}
