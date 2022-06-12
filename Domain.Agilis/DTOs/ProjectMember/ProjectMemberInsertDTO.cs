using System.ComponentModel.DataAnnotations;

namespace Domain.Agilis.DTOs.ProjectMember
{
    public class ProjectMemberInsertDTO
    {
        [Required(ErrorMessage = "IdProject required")]
        public int IdProject { get; set; }

        [Required(ErrorMessage = "IdMember required")]
        public int IdMember { get; set; }
    }
}
