using Microsoft.EntityFrameworkCore;

namespace Repository.Agilis
{
    public class AgilisDbContext : DbContext
    {
        public AgilisDbContext() { }

        public AgilisDbContext(DbContextOptions<AgilisDbContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=Fabiano;Database=agilis;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
