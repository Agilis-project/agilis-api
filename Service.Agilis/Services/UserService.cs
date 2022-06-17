using Domain.Agilis.DTOs.Member;
using Domain.Agilis.DTOs.User;
using Domain.Agilis.Entities;
using Domain.Agilis.Interfaces.Repositories;
using Domain.Agilis.Interfaces.Services;
using Domain.Agilis.Utils;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Agilis.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IMemberService _memberService;

        public UserService(IUserRepository userRepository, IMemberService memberService)
        {
            _userRepository = userRepository;
            _memberService = memberService;
        }

        public List<UserOutputDTO> GetAllUsers()
        {
            return _userRepository.GetAllWithMember().Select(x =>
            {
                return new UserOutputDTO()
                {
                    Id = x.Id,
                    Email = x.Email,
                    Role = x.Role,
                    Active = x.Active,
                    Members = x.Members.Select(x =>
                    {
                        return new MemberOutputDTO()
                        {
                            Id = x.Id,
                            Name = x.Name,
                            IdUser = x.IdUser,
                            Active = x.Active
                        };
                    }).ToList()
                };
            }).ToList();
        }

        public UserOutputDTO GetByIdUser(int id)
        {
            if (id < 0)
                throw new ArgumentException($"Id: {id} está inválido");

            var user = _userRepository.GetByIdWithMember(id);

            if (user == null)
                throw new KeyNotFoundException($"Id: {id} não encontrado");

            return new UserOutputDTO()
            {
                Id = user.Id,
                Email = user.Email,
                Role = user.Role,
                Active = user.Active,
                Members = user.Members.Select(x =>
                {
                    return new MemberOutputDTO()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        IdUser = x.IdUser,
                        Active = x.Active
                    };
                }).ToList()
            };
        }

        public UserOutputDTO InsertUser(UserInsertDTO userInsertDTO)
        {
            this.ExistEmail(userInsertDTO.Email);

            var members = new List<MemberEntity>()
            {
                new MemberEntity()
                {
                    Name = userInsertDTO.Name,
                    Active = true
                }
            };

            var user = new UserEntity()
            {
                Email = userInsertDTO.Email,
                Password = Cryptography.getMdIHash(userInsertDTO.Password),
                Role = userInsertDTO.Role,
                Active = true,
                Members = members
            };

            _userRepository.Insert(user);

            if (user.Id == 0)
                throw new NullReferenceException("Falha ao inserir User");

            return new UserOutputDTO()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
                Active = user.Active,
                Members = user.Members.Select(x =>
                {
                    return new MemberOutputDTO()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        IdUser = x.IdUser,
                        Active = x.Active
                    };
                }).ToList()
            };
        }

        public UserOutputDTO UpdateUser(UserUpdateDTO userUpdateDTO)
        {
            this.GetByIdUser(userUpdateDTO.Id);
            this.ExistEmail(userUpdateDTO.Email, userUpdateDTO.Id);

            var membersUpdate = new List<MemberEntity>()
            {
                new MemberEntity()
                {
                    Name = userUpdateDTO.Name,
                    Active = true
                }
            };

            var userUpdate = new UserEntity()
            {
                Email = userUpdateDTO.Email,
                Role = userUpdateDTO.Role,
                Active = true,
                Members = membersUpdate
            };

            if (string.IsNullOrEmpty(userUpdateDTO.Password))
                userUpdate.Password = _userRepository.GetPasswordEncryptedById(userUpdate.Id);
            else
                userUpdate.Password = Cryptography.getMdIHash(userUpdateDTO.Password);
                
            _userRepository.Update(userUpdate);

            return new UserOutputDTO()
            {
                Id = userUpdate.Id,
                Email = userUpdate.Email,
                Password = userUpdate.Password,
                Role = userUpdate.Role,
                Active = userUpdate.Active,
                Members = userUpdate.Members.Select(x =>
                {
                    return new MemberOutputDTO()
                    {
                        Id = x.Id,
                        Name = x.Name,
                        IdUser = x.IdUser,
                        Active = x.Active
                    };
                }).ToList()
            };
        }

        public void DeleteUser(int id)
        {
            if (id < 1)
                throw new ArgumentException($"Id: {id} está inválido");

            if (!_userRepository.Delete(id))
                throw new KeyNotFoundException($"Id: {id} não encontrado");

            _memberService.DeleteMemberWithIdUser(id);
        }

        private void ExistEmail(string email, int id = 0)
        {
            if (_userRepository.ExistEmailEquals(email, id))
                throw new ArgumentException($"Email: {email} já existe");
        }
    }
}
