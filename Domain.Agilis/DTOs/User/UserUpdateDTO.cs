using Domain.Agilis.Enums;
using System.ComponentModel.DataAnnotations;

namespace Domain.Agilis.DTOs.User
{
    public class UserUpdateDTO
    {
        [Required(ErrorMessage = "IdUser required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "EmailUser required")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PasswordUser required")]
        public string Password { get; set; }

        [Required(ErrorMessage = "RoleUser required")]
        public ERoleUser Role { get; set; }

        [Required(ErrorMessage = "IdMember required")]
        public int IdMember { get; set; }

        [Required(ErrorMessage = "NameMember required")]
        public string Name { get; set; }
    }
}
