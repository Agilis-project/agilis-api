using Domain.Agilis.Interfaces.Repositories;
using Domain.Agilis.Interfaces.Services;

namespace Service.Agilis.Services
{
    public class ProjectMemberService : IProjectMemberService
    {
        private readonly IProjectMemberRepository _projectMemberRepository;

        public ProjectMemberService(IProjectMemberRepository projectMemberRepository)
        {
            _projectMemberRepository = projectMemberRepository;
        }
    }
}
