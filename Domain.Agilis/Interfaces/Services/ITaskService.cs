using Domain.Agilis.DTOs.Task;
using System.Collections.Generic;

namespace Domain.Agilis.Interfaces.Services
{
    public interface ITaskService
    {
        List<TaskOutputDTO> GetAllTasks();
        TaskOutputDTO GetByIdTask(int id);
        List<TaskOutputDTO> GetTasksByIdSprint(int idSprint);
        TaskOutputDTO InsertTask(TaskInsertDTO taskInsertDTO);
        TaskOutputDTO UpdateTask(TaskUpdateDTO taskUpdateDTO);
        void DeleteTask(int id);
    }
}