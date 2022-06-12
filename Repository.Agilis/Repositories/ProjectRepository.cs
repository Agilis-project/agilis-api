using Domain.Agilis.Entities;
using Domain.Agilis.Interfaces.Repositories;

namespace Repository.Agilis.Repositories
{
    public class ProjectRepository : RepositoryBase<ProjectEntity>, IProjectRepository
    {
        public ProjectRepository(AgilisDbContext context) : base(context) { }
    }
}
