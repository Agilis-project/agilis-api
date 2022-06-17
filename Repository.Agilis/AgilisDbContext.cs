using Domain.Agilis.Entities;
using Microsoft.EntityFrameworkCore;
using Repository.Agilis.Mapping;
using Repository.Agilis.Seeds;

namespace Repository.Agilis
{
    public class AgilisDbContext : DbContext
    {
        public AgilisDbContext() { }

        public AgilisDbContext(DbContextOptions<AgilisDbContext> options) : base(options) { }

        public DbSet<ProjectEntity> Project { get; set; }
        public DbSet<MemberEntity> Member { get; set; }
        public DbSet<SprintEntity> Sprint { get; set; }
        public DbSet<TaskEntity> Task { get; set; }
        public DbSet<UserEntity> User { get; set; }
        public DbSet<ProjectMemberEntity> ProjectMember { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=tcp:fourline.database.windows.net,1433;Initial Catalog=agilisDB;Persist Security Info=False;User ID=fourlineadmin;Password=Ies300@fatec;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ProjectEntity>(new ProjectMap().Configure);
            modelBuilder.Entity<MemberEntity>(new MemberMap().Configure);
            modelBuilder.Entity<SprintEntity>(new SprintMap().Configure);
            modelBuilder.Entity<TaskEntity>(new TaskMap().Configure);
            modelBuilder.Entity<UserEntity>(new UserMap().Configure);
            modelBuilder.Entity<ProjectMemberEntity>(new ProjectMemberMap().Configure);

            base.OnModelCreating(modelBuilder);

            UserSeed.Users(modelBuilder);
        }
    }
}
