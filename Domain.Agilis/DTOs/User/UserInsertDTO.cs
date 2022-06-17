using Domain.Agilis.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Agilis.DTOs.User
{
    public class UserInsertDTO
    {
        [Required(ErrorMessage = "EmailUser required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PasswordUser required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "RoleUser required")]
        public ERoleUser Role { get; set; }

        [Required(ErrorMessage = "NameMember required")]
        public string Name { get; set; }
    }
}
