using Domain.Agilis.Entities;
using System.Collections.Generic;

namespace Domain.Agilis.Interfaces.Repositories
{
    public interface ISprintRepository : IRepositoryBase<SprintEntity>
    {
        SprintEntity GetSprintBacklog(int idProject);
        List<SprintEntity> GetAllSprintsByIdProject(int idProject);
    }
}
