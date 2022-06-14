using Domain.Agilis.DTOs.Sprint;
using Domain.Agilis.Interfaces.Repositories;
using Domain.Agilis.Interfaces.Services;
using System.Collections.Generic;

namespace Service.Agilis.Services
{
    public class SprintService : ISprintService
    {
        private readonly ISprintRepository _sprintRepository;

        public SprintService(ISprintRepository sprintRepository)
        {
            _sprintRepository = sprintRepository;
        }

        public void DeleteSprint(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<SprintOutputDTO> GetAllSprints()
        {
            throw new System.NotImplementedException();
        }

        public SprintOutputDTO GetByIdSprint(int id)
        {
            throw new System.NotImplementedException();
        }

        public SprintOutputDTO InsertSprint(SprintInsertDTO sprintInsertDTO)
        {
            throw new System.NotImplementedException();
        }

        public SprintOutputDTO UpdateSprint(SprintUpdateDTO sprintUpdateDTO)
        {
            throw new System.NotImplementedException();
        }
    }
}
