using Domain.Agilis.DTOs.Member;
using Domain.Agilis.Interfaces.Repositories;
using Domain.Agilis.Interfaces.Services;
using System.Collections.Generic;

namespace Service.Agilis.Services
{
    public class MemberService : IMemberService
    {
        private readonly IMemberRepository _memberRepository;

        public MemberService(IMemberRepository memberRepository)
        {
            _memberRepository = memberRepository;
        }

        public void DeleteMember(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<MemberOutputDTO> GetAllMembers()
        {
            throw new System.NotImplementedException();
        }

        public MemberOutputDTO GetByIdMember(int id)
        {
            throw new System.NotImplementedException();
        }

        public MemberOutputDTO InsertMember(MemberInsertDTO memberInsertDTO)
        {
            throw new System.NotImplementedException();
        }

        public MemberOutputDTO UpdateMember(MemberUpdateDTO memberUpdateDTO)
        {
            throw new System.NotImplementedException();
        }
    }
}
