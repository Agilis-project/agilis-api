using Domain.Agilis.Entities;
using System.Collections.Generic;

namespace Domain.Agilis.Interfaces.Repositories
{
    public interface ITaskRepository : IRepositoryBase<TaskEntity>
    {
        List<TaskEntity> GetTasksByIdSprint(int idSprint);
    }
}
