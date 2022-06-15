using Domain.Agilis.Entities;
using Domain.Agilis.Interfaces.Repositories;
using System.Linq;

namespace Repository.Agilis.Repositories
{
    public class UserRepository : RepositoryBase<UserEntity>, IUserRepository
    {
        public UserRepository(AgilisDbContext context) : base(context) { }

        public bool ExistEmailEquals(string email, int id)
        {
            return _dbSet.Where(x => x.Id != id).Any(x => x.Email.ToUpper() == email.ToUpper());
        }
    }
}
