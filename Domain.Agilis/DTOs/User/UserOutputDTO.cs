using Domain.Agilis.Enums;

namespace Domain.Agilis.DTOs.User
{
    public class UserOutputDTO
    {
        public int Id { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public ERoleUser Role { get; set; }

        public bool Active { get; set; }
    }
}
