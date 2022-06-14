using Domain.Agilis.DTOs.User;
using System.Collections.Generic;

namespace Domain.Agilis.Interfaces.Services
{
    public interface IUserService
    {
        List<UserOutputDTO> GetAllUsers();
        UserOutputDTO GetByIdUser(int id);
        UserOutputDTO InsertUser(UserInsertDTO userInsertDTO);
        UserOutputDTO UpdateUser(UserUpdateDTO userUpdateDTO);
        void DeleteUser(int id);
    }
}
