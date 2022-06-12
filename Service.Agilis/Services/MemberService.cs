using Domain.Agilis.Interfaces.Repositories;
using Domain.Agilis.Interfaces.Services;

namespace Service.Agilis.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }
    }
}
