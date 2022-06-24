using Domain.Agilis.Entities;
using Domain.Agilis.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Agilis.Repositories
{
    public class SprintRepository : RepositoryBase<SprintEntity>, ISprintRepository
    {
        public SprintRepository(AgilisDbContext context) : base(context) { }

        public List<SprintEntity> GetAllSprintsByIdProject(int idProject)
        {
            return _dbSet.Where(x => x.IdProject == idProject && x.Active && x.Name.ToUpper() != "BACKLOG").ToList();
        }

        public SprintEntity GetSprintBacklog(int idProject)
        {
            return _dbSet.FirstOrDefault(x => x.Name.ToUpper() == "BACKLOG" && x.IdProject == idProject && x.Active == true);
        }
    }
}
