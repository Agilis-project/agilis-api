using Domain.Agilis.Interfaces.Repositories;
using Domain.Agilis.Interfaces.Services;

namespace Service.Agilis.Services
{
    public class SprintService : ISprintService
    {
        private readonly ISprintRepository _sprintRepository;

        public SprintService(ISprintRepository sprintRepository)
        {
            _sprintRepository = sprintRepository;
        }
    }
}
