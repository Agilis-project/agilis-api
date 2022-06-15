using Domain.Agilis.DTOs.Project;
using Domain.Agilis.Interfaces.Repositories;
using Domain.Agilis.Interfaces.Services;
using System.Collections.Generic;

namespace Service.Agilis.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }

        public List<ProjectOutputDTO> GetAllProjects()
        {
            throw new System.NotImplementedException();
        }

        public ProjectOutputDTO GetByIdProject(int id)
        {
            throw new System.NotImplementedException();
        }

        public ProjectOutputDTO InsertProject(ProjectInsertDTO projectInsertDTO)
        {
            throw new System.NotImplementedException();
        }

        public ProjectOutputDTO UpdateProject(ProjectUpdateDTO projectUpdateDTO)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteProject(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
