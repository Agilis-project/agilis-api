using Domain.Agilis.Interfaces.Repositories;
using Domain.Agilis.Interfaces.Services;
using System;
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

        public void DeleteMemberWithIdUser(int idUser)
        {
            if (idUser < 1)
                throw new ArgumentException($"Id: {idUser} está inválido");

            if (!_memberRepository.DeleteWithIdUser(idUser))
                throw new KeyNotFoundException($"Id: {idUser} não encontrado");
        }
    }
}
