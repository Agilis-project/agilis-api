using Domain.Agilis.Entities;
using Domain.Agilis.Interfaces.Repositories;

namespace Repository.Agilis.Repositories
{
    public class ProjectMemberRepository : RepositoryBase<ProjectMemberEntity>, IProjectMemberRepository
    {
        public ProjectMemberRepository(AgilisDbContext context) : base(context) { }
    }
}
