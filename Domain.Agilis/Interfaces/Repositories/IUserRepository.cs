using Domain.Agilis.Entities;
using System.Collections.Generic;

namespace Domain.Agilis.Interfaces.Repositories
{
    public interface IUserRepository : IRepositoryBase<UserEntity>
    {
        bool ExistEmailEquals(string email, int id);
        List<UserEntity> GetAllWithMember();
        UserEntity GetByIdWithMember(int id, bool asNoTracking = true);
    }
}
