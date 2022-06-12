using System.ComponentModel.DataAnnotations;

namespace Domain.Agilis.DTOs.ProjectMember
{
    public class ProjectMemberUpdateDTO
    {
        [Required(ErrorMessage = "IdProjectMember required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "IdProject required")]
        public int IdProject { get; set; }

        [Required(ErrorMessage = "IdMember required")]
        public int IdMember { get; set; }
    }
}
