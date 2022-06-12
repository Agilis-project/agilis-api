using Domain.Agilis.Entities;
using Domain.Agilis.Interfaces.Repositories;

namespace Repository.Agilis.Repositories
{
    public class MemberRepository : RepositoryBase<MemberEntity>, IMemberRepository
    {
        public MemberRepository(AgilisDbContext context) : base(context) { }
    }
}
