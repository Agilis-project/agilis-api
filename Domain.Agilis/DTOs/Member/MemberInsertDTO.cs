using System.ComponentModel.DataAnnotations;

namespace Domain.Agilis.DTOs.Member
{
    public class MemberInsertDTO
    {
        [Required(ErrorMessage = "NameMember required")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "IdUser required")]
        public int IdUser { get; set; }
    }
}
