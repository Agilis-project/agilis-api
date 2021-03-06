using Domain.Agilis.DTOs.Sprint;
using System.Collections.Generic;

namespace Domain.Agilis.Interfaces.Services
{
    public interface ISprintService
    {
        List<SprintOutputDTO> GetAllSprints();
        SprintOutputDTO GetByIdSprint(int id);
        SprintOutputDTO GetSprintBacklog(int idProject);
        List<SprintOutputDTO> GetAllSprintsByIdProject(int idProject);
        SprintOutputDTO InsertSprint(SprintInsertDTO sprintInsertDTO);
        SprintOutputDTO UpdateSprint(SprintUpdateDTO sprintUpdateDTO);
        void DeleteSprint(int id);
    }
}
