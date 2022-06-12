using System;

namespace Domain.Agilis.DTOs.Project
{
    public class ProjectOutputDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public bool Active { get; set; }
    }
}
