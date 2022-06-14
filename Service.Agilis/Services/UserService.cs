using Domain.Agilis.DTOs.User;
using Domain.Agilis.Interfaces.Repositories;
using Domain.Agilis.Interfaces.Services;
using System.Collections.Generic;

namespace Service.Agilis.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public void DeleteUser(int id)
        {
            throw new System.NotImplementedException();
        }

        public List<UserOutputDTO> GetAllUsers()
        {
            throw new System.NotImplementedException();
        }

        public UserOutputDTO GetByIdUser(int id)
        {
            throw new System.NotImplementedException();
        }

        public UserOutputDTO InsertUser(UserInsertDTO userInsertDTO)
        {
            throw new System.NotImplementedException();
        }

        public UserOutputDTO UpdateUser(UserUpdateDTO userUpdateDTO)
        {
            throw new System.NotImplementedException();
        }
    }
}
