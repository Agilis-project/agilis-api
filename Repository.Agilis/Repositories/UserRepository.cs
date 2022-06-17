using Domain.Agilis.Entities;
using Domain.Agilis.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
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

        public List<UserEntity> GetAllWithMember()
        {
            return _dbSet.Where(x => x.Active == true).Include(x => x.Members).ToList();
        }

        public UserEntity GetByIdWithMember(int id, bool asNoTracking = true)
        {
            IQueryable<UserEntity> query = _dbSet;
            if (asNoTracking)
                query = query.AsNoTracking();

            return query.Where(x => x.Active == true).Include(x => x.Members).FirstOrDefault(x => x.Id == id);
        }

        public string GetPasswordEncryptedById(int id)
        {
            return _dbSet.Where(x => x.Id == id).Select(x => x.Password).FirstOrDefault();
        }

        public UserEntity LoginUser(string email, string password)
        {
            return _dbSet.Where(x => x.Email.ToUpper().Equals(email.ToUpper()) && 
                                     x.Password.Equals(password) &&
                                     x.Active == true)
                         .Include(x => x.Members)
                         .FirstOrDefault();
        }
    }
}
