using Domain.Agilis.DTOs.User;
using Domain.Agilis.Entities;
using Domain.Agilis.Interfaces.Repositories;
using Domain.Agilis.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Service.Agilis.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<UserOutputDTO> GetAllUsers()
        {
            return _userRepository.GetAll().Select(x =>
            {
                return new UserOutputDTO()
                {
                    Id = x.Id,
                    Email = x.Email,
                    Password = x.Password,
                    Role = x.Role,
                    Active = x.Active
                };
            }).ToList();
        }

        public UserOutputDTO GetByIdUser(int id)
        {
            if (id < 0)
                throw new ArgumentException($"Id: {id} está inválido");

            var user = _userRepository.GetById(id);

            if(user == null)
                throw new KeyNotFoundException($"Id: {id} não encontrado");

            return new UserOutputDTO()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
                Active = user.Active
            };
        }

        public UserOutputDTO InsertUser(UserInsertDTO userInsertDTO)
        {
            this.ExistEmail(userInsertDTO.Email);

            var user = new UserEntity()
            {
                Email = userInsertDTO.Email,
                Password = userInsertDTO.Password,
                Role = userInsertDTO.Role,
                Active = true
            };

            _userRepository.Insert(user);

            if(user.Id == 0)
                throw new NullReferenceException("Falha ao inserir User");

            return new UserOutputDTO()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
                Active = user.Active
            };
        }

        public UserOutputDTO UpdateUser(UserUpdateDTO userUpdateDTO)
        {
            var user = this.GetByIdUser(userUpdateDTO.Id);
            this.ExistEmail(userUpdateDTO.Email, userUpdateDTO.Id);

            var userUpdate = new UserEntity()
            {
                Email = userUpdateDTO.Email,
                Password = userUpdateDTO.Password,
                Role = userUpdateDTO.Role,
                Active = true
            };

            _userRepository.Update(userUpdate);

            return new UserOutputDTO()
            {
                Id = user.Id,
                Email = user.Email,
                Password = user.Password,
                Role = user.Role,
                Active = user.Active
            };
        }

        public void DeleteUser(int id)
        {
            if (id < 1)
                throw new ArgumentException($"Id: {id} está inválido");

            if (!_userRepository.Delete(id))
                throw new KeyNotFoundException($"Id: {id} não encontrado");
        }

        private void ExistEmail(string email, int id = 0)
        {
            if (_userRepository.ExistEmailEquals(email, id))
                throw new ArgumentException($"Email: {email} já existe");
        }
    }
}
