using Domain.Agilis.Entities;
using Domain.Agilis.Interfaces.Repositories;

namespace Repository.Agilis.Repositories
{
    public class TaskRepository : RepositoryBase<TaskEntity>, ITaskRepository
    {
        public TaskRepository(AgilisDbContext context) : base(context) { }
    }
}
