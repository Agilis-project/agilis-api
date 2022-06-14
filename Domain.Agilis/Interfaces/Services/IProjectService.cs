using Domain.Agilis.DTOs.Project;
using System.Collections.Generic;

namespace Domain.Agilis.Interfaces.Services
{
    public interface IProjectService
    {
        List<ProjectOutputDTO> GetAllProjects();
        ProjectOutputDTO GetByIdProject(int id);
        ProjectOutputDTO InsertProject(ProjectInsertDTO projectInsertDTO);
        ProjectOutputDTO UpdateProject(ProjectUpdateDTO projectUpdateDTO);
        void DeleteProject(int id);
    }
}
