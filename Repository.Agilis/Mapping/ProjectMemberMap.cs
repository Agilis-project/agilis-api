using Domain.Agilis.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Agilis.Mapping
{
    public class ProjectMemberMap : IEntityTypeConfiguration<ProjectMemberEntity>
    {
        public void Configure(EntityTypeBuilder<ProjectMemberEntity> builder)
        {
            builder.ToTable("ProjectMember");
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Active);
            builder.HasOne(x => x.Member).WithMany(x => x.ProjectMember).HasForeignKey(x => x.IdMember);
            builder.HasOne(x => x.Project).WithMany(x => x.ProjectMember).HasForeignKey(x => x.IdProject);
        }
    }
}
