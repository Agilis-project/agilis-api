using Domain.Agilis.DTOs.Task;
using Domain.Agilis.Entities;
using Domain.Agilis.Interfaces.Repositories;
using Domain.Agilis.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Agilis.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }

        public List<TaskOutputDTO> GetAllTasks()
        {
            return _taskRepository.GetAll().Select(x =>
            {
                return new TaskOutputDTO()
                {
                    Id = x.Id,
                    Name = x.Name,
                    Description = x.Description,
                    StartDate = x.StartDate,
                    EndDate = x.EndDate,
                    Status = x.Status,
                    ReleaseDate = x.ReleaseDate,
                    TaskNumber = x.TaskNumber,
                    IdMember = x.IdMember,
                    IdSprint = x.IdSprint,
                    Active = x.Active
                };
            }).ToList();
        }

        public TaskOutputDTO GetByIdTask(int id)
        {
            if (id < 0)
                throw new ArgumentException($"Id: {id} está inválido");

            var task = _taskRepository.GetById(id);

            if (task == null)
                throw new KeyNotFoundException($"Id: {id} não encontrado");

            return new TaskOutputDTO()
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                Status = task.Status,
                ReleaseDate = task.ReleaseDate,
                TaskNumber = task.TaskNumber,
                IdMember = task.IdMember,
                IdSprint = task.IdSprint,
                Active = task.Active
            };
        }

        public TaskOutputDTO InsertTask(TaskInsertDTO taskInsertDTO)
        {
            var task = new TaskEntity()
            {
                Name = taskInsertDTO.Name,
                Description = taskInsertDTO.Description,
                StartDate = taskInsertDTO.StartDate,
                EndDate = taskInsertDTO.EndDate,
                Status = taskInsertDTO.Status,
                ReleaseDate = taskInsertDTO.ReleaseDate,
                TaskNumber = taskInsertDTO.TaskNumber,
                IdMember = taskInsertDTO.IdMember,
                IdSprint = taskInsertDTO.IdSprint,
                Active = true
            };

            _taskRepository.Insert(task);

            if (task.Id == 0)
                throw new NullReferenceException("Falha ao inserir Task");

            return new TaskOutputDTO()
            {
                Id = task.Id,
                Name = task.Name,
                Description = task.Description,
                StartDate = task.StartDate,
                EndDate = task.EndDate,
                Status = task.Status,
                ReleaseDate = task.ReleaseDate,
                TaskNumber = task.TaskNumber,
                IdMember = task.IdMember,
                IdSprint = task.IdSprint,
                Active = task.Active
            };
        }

        public TaskOutputDTO UpdateTask(TaskUpdateDTO taskUpdateDTO)
        {
            this.GetByIdTask(taskUpdateDTO.Id);

            var projectUpdate = new TaskEntity()
            {
                Name = taskUpdateDTO.Name,
                Description = taskUpdateDTO.Description,
                StartDate = taskUpdateDTO.StartDate,
                EndDate = taskUpdateDTO.EndDate,
                Status = taskUpdateDTO.Status,
                ReleaseDate = taskUpdateDTO.ReleaseDate,
                TaskNumber = taskUpdateDTO.TaskNumber,
                IdMember = taskUpdateDTO.IdMember,
                IdSprint = taskUpdateDTO.IdSprint,
                Active = true
            };

            _taskRepository.Update(projectUpdate);

            return new TaskOutputDTO()
            {
                Id = projectUpdate.Id,
                Name = projectUpdate.Name,
                Description = projectUpdate.Description,
                StartDate = projectUpdate.StartDate,
                EndDate = projectUpdate.EndDate,
                Status = projectUpdate.Status,
                ReleaseDate = projectUpdate.ReleaseDate,
                TaskNumber = projectUpdate.TaskNumber,
                IdMember = projectUpdate.IdMember,
                IdSprint = projectUpdate.IdSprint,
                Active = projectUpdate.Active
            };
        }

        public void DeleteTask(int id)
        {
            if (id < 1)
                throw new ArgumentException($"Id: {id} está inválido");

            if (!_taskRepository.Delete(id))
                throw new KeyNotFoundException($"Id: {id} não encontrado");
        }
    }
}
