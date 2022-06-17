using Domain.Agilis.DTOs.Project;
using Domain.Agilis.Entities;
using Domain.Agilis.Interfaces.Repositories;
using Domain.Agilis.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

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
            return _projectRepository.GetAll().Select(x =>
            {
                return new ProjectOutputDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    StartDate = x.StartDate.Date,
                    EndDate = x.StartDate.Date,
                    Active = x.Active
                };
            }).ToList();
        }

        public ProjectOutputDTO GetByIdProject(int id)
        {
            if (id < 0)
                throw new ArgumentException($"Id: {id} está inválido");

            var project = _projectRepository.GetById(id);

            if (project == null)
                throw new KeyNotFoundException($"Id: {id} não encontrado");

            return new ProjectOutputDTO()
            {
                Id = project.Id,
                Name = project.Name,
                StartDate = project.StartDate.Date,
                EndDate = project.StartDate.Date,
                Active = project.Active
            };
        }

        public ProjectOutputDTO InsertProject(ProjectInsertDTO projectInsertDTO)
        {
            var project = new ProjectEntity()
            {
                Name = projectInsertDTO.Name,
                StartDate = projectInsertDTO.StartDate.Date,
                EndDate = projectInsertDTO.EndDate.Date,
                Active = true
            };

            _projectRepository.Insert(project);

            if (project.Id == 0)
                throw new NullReferenceException("Falha ao inserir Project");

            return new ProjectOutputDTO()
            {
                Id = project.Id,
                Name = project.Name,
                StartDate = project.StartDate.Date,
                EndDate = project.EndDate.Date,
                Active = project.Active
            };
        }

        public ProjectOutputDTO UpdateProject(ProjectUpdateDTO projectUpdateDTO)
        {
            this.GetByIdProject(projectUpdateDTO.Id);

            var projectUpdate = new ProjectEntity()
            {
                Name = projectUpdateDTO.Name,
                StartDate = projectUpdateDTO.StartDate.Date,
                EndDate = projectUpdateDTO.EndDate.Date,
                Active = true
            };

            _projectRepository.Update(projectUpdate);

            return new ProjectOutputDTO()
            {
                Id = projectUpdate.Id,
                Name = projectUpdate.Name,
                StartDate = projectUpdate.StartDate.Date,
                EndDate = projectUpdate.EndDate.Date,
                Active = projectUpdate.Active
            };
        }

        public void DeleteProject(int id)
        {
            if (id < 1)
                throw new ArgumentException($"Id: {id} está inválido");

             if (!_projectRepository.Delete(id))
                throw new KeyNotFoundException($"Id: {id} não encontrado");
        }
    }
}
