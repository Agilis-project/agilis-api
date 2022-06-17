using System.ComponentModel.DataAnnotations;

namespace Domain.Agilis.DTOs.User
{
    public class UserLoginDTO
    {
        [Required(ErrorMessage = "EmailUser required")]
        [EmailAddress(ErrorMessage = "Format email invalid")]
        public string Email { get; set; }

        [Required(ErrorMessage = "PasswordUser required")]
        public string Password { get; set; }
    }
}
