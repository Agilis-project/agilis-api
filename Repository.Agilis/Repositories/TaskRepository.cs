using Domain.Agilis.Entities;
using Domain.Agilis.Interfaces.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Repository.Agilis.Repositories
{
    public class TaskRepository : RepositoryBase<TaskEntity>, ITaskRepository
    {
        public TaskRepository(AgilisDbContext context) : base(context) { }

        public List<TaskEntity> GetTasksByIdSprint(int idSprint)
        {
            return _dbSet.Where(x => x.Active == true && x.IdSprint == idSprint).ToList();
        }
    }
}
