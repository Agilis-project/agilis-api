using Domain.Agilis.DTOs.Member;
using System.Collections.Generic;

namespace Domain.Agilis.Interfaces.Services
{
    public interface IMemberService
    {
        List<MemberOutputDTO> GetAllMembers();
        MemberOutputDTO GetByIdMember(int id);
        MemberOutputDTO InsertMember(MemberInsertDTO memberInsertDTO);
        MemberOutputDTO UpdateMember(MemberUpdateDTO memberUpdateDTO);
        void DeleteMember(int id);
    }
}
