using Domain.Agilis.Entities;
using Domain.Agilis.Interfaces.Repositories;

namespace Repository.Agilis.Repositories
{
    public class UserRepository : RepositoryBase<UserEntity>, IUserRepository
    {
        public UserRepository(AgilisDbContext context) : base(context) { }
    }
}
