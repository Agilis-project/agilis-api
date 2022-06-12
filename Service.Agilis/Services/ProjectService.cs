using Domain.Agilis.Interfaces.Repositories;
using Domain.Agilis.Interfaces.Services;

namespace Service.Agilis.Services
{
    public class ProjectService : IProjectService
    {
        private readonly IProjectRepository _projectRepository;

        public ProjectService(IProjectRepository projectRepository)
        {
            _projectRepository = projectRepository;
        }
    }
}
