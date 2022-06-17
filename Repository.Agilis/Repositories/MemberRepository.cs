using Domain.Agilis.Entities;
using Domain.Agilis.Interfaces.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Repository.Agilis.Repositories
{
    public class MemberRepository : RepositoryBase<MemberEntity>, IMemberRepository
    {
        public MemberRepository(AgilisDbContext context) : base(context) { }

        public bool DeleteWithIdUser(int idUser)
        {
            var entity = _dbSet.AsNoTracking().Where(x => x.Active == true).FirstOrDefault(x => x.IdUser == idUser);

            if (entity != null && entity.Active)
            {
                entity.Active = false;
                _dbSet.Update(entity);
                _context.SaveChanges();

                return true;
            }

            return false;
        }
    }
}
