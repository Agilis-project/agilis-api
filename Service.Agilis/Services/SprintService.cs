using Domain.Agilis.DTOs.Sprint;
using Domain.Agilis.Entities;
using Domain.Agilis.Interfaces.Repositories;
using Domain.Agilis.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Agilis.Services
{
    public class SprintService : ISprintService
    {
        private readonly ISprintRepository _sprintRepository;

        public SprintService(ISprintRepository sprintRepository)
        {
            _sprintRepository = sprintRepository;
        }

        public List<SprintOutputDTO> GetAllSprints()
        {
            return _sprintRepository.GetAll().Select(x =>
            {
                return new SprintOutputDTO()
                {
                    Id = x.Id,
                    SprintNumber = x.SprintNumber,
                    Name = x.Name,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Active = x.Active,
                    IdProject = x.IdProject
                };
            }).ToList();
        }

        public SprintOutputDTO GetByIdSprint(int id)
        {
            if (id < 0)
                throw new ArgumentException($"Id: {id} está inválido");

            var sprint = _sprintRepository.GetById(id);

            if (sprint == null)
                throw new KeyNotFoundException($"Id: {id} não encontrado");

            return new SprintOutputDTO()
            {
                Id = sprint.Id,
                SprintNumber = sprint.SprintNumber,
                Name = sprint.Name,
                StartDate = sprint.StartDate,
                EndDate = sprint.EndDate,
                Active = sprint.Active,
                IdProject = sprint.IdProject
            };
        }

        public SprintOutputDTO InsertSprint(SprintInsertDTO sprintInsertDTO)
        {
            var sprint = new SprintEntity()
            {
                Name = sprintInsertDTO.Name,
                SprintNumber = sprintInsertDTO.SprintNumber,
                StartDate = sprintInsertDTO.StartDate,
                EndDate = sprintInsertDTO.EndDate,
                IdProject = sprintInsertDTO.IdProject,
                Active = true
            };

            _sprintRepository.Insert(sprint);

            if (sprint.Id == 0)
                throw new NullReferenceException("Falha ao inserir Sprint");

            return new SprintOutputDTO()
            {
                Id = sprint.Id,
                Name = sprint.Name,
                SprintNumber = sprint.SprintNumber,
                StartDate = sprint.StartDate,
                EndDate = sprint.EndDate,
                IdProject = sprint.IdProject,
                Active = sprint.Active
            };
        }

        public SprintOutputDTO UpdateSprint(SprintUpdateDTO sprintUpdateDTO)
        {
            this.GetByIdSprint(sprintUpdateDTO.Id);

            var sprintUpdate = new SprintEntity()
            {
                Name = sprintUpdateDTO.Name,
                SprintNumber = sprintUpdateDTO.SprintNumber,
                StartDate = sprintUpdateDTO.StartDate,
                EndDate = sprintUpdateDTO.EndDate,
                IdProject = sprintUpdateDTO.IdProject,
                Active = true
            };

            _sprintRepository.Update(sprintUpdate);

            return new SprintOutputDTO()
            {
                Id = sprintUpdate.Id,
                Name = sprintUpdate.Name,
                SprintNumber = sprintUpdate.SprintNumber,
                StartDate = sprintUpdate.StartDate,
                EndDate = sprintUpdate.EndDate,
                IdProject = sprintUpdate.IdProject,
                Active = sprintUpdate.Active
            };
        }
        public void DeleteSprint(int id)
        {
            if (id < 1)
                throw new ArgumentException($"Id: {id} está inválido");

            if (!_sprintRepository.Delete(id))
                throw new KeyNotFoundException($"Id: {id} não encontrado");
        }

        public SprintOutputDTO GetSprintBacklog(int idProject)
        {
            if (idProject < 0)
                throw new ArgumentException($"Id: {idProject} está inválido");

            var sprintBaklog = _sprintRepository.GetSprintBacklog(idProject);

            if(sprintBaklog == null)
                throw new KeyNotFoundException($"Backlog não encontrado");

            return new SprintOutputDTO()
            {
                Id = sprintBaklog.Id,
                Name = sprintBaklog.Name,
                SprintNumber = sprintBaklog.SprintNumber,
                StartDate = sprintBaklog.StartDate,
                EndDate = sprintBaklog.EndDate,
                IdProject = sprintBaklog.IdProject,
                Active = sprintBaklog.Active
            };
        }

        public List<SprintOutputDTO> GetAllSprintsByIdProject(int idProject)
        {
            if (idProject < 0)
                throw new ArgumentException($"Id: {idProject} está inválido");

            var sprintsProject = _sprintRepository.GetAllSprintsByIdProject(idProject);

            if (sprintsProject.Count() <= 0)
                throw new KeyNotFoundException($"Projeto sem sprints");

            return sprintsProject.Select(x =>
            {
                return new SprintOutputDTO()
                {
                    Id = x.Id,
                    SprintNumber = x.SprintNumber,
                    Name = x.Name,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Active = x.Active,
                    IdProject = x.IdProject
                };
            }).ToList();
        }
    }
}
