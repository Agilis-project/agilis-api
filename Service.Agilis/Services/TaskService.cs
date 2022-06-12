using Domain.Agilis.Interfaces.Repositories;
using Domain.Agilis.Interfaces.Services;

namespace Service.Agilis.Services
{
    public class TaskService : ITaskService
    {
        private readonly ITaskRepository _taskRepository;

        public TaskService(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
    }
}
