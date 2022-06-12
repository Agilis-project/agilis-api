using Domain.Agilis.Interfaces.Repositories;
using Domain.Agilis.Interfaces.Services;

namespace Service.Agilis.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
    }
}
