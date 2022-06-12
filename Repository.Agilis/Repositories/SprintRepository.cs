using Domain.Agilis.Entities;
using Domain.Agilis.Interfaces.Repositories;

namespace Repository.Agilis.Repositories
{
    public class SprintRepository : RepositoryBase<SprintEntity>, ISprintRepository
    {
        public SprintRepository(AgilisDbContext context) : base(context) { }
    }
}
