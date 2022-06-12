namespace Domain.Agilis.DTOs.ProjectMember
{
    public class ProjectMemberOutputDTO
    {
        public int Id { get; set; }

        public int IdProject { get; set; }

        public int IdMember { get; set; }

        public bool Active { get; set; }
    }
}
