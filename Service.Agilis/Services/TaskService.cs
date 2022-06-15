using Domain.Agilis.DTOs.Task;
using Domain.Agilis.Interfaces.Repositories;
using Domain.Agilis.Interfaces.Services;
using System.Collections.Generic;

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
            throw new System.NotImplementedException();
        }

        public TaskOutputDTO GetByIdTask(int id)
        {
            throw new System.NotImplementedException();
        }

        public TaskOutputDTO InsertTask(TaskInsertDTO taskInsertDTO)
        {
            throw new System.NotImplementedException();
        }

        public TaskOutputDTO UpdateTask(TaskUpdateDTO taskUpdateDTO)
        {
            throw new System.NotImplementedException();
        }

        public void DeleteTask(int id)
        {
            throw new System.NotImplementedException();
        }
    }
}
