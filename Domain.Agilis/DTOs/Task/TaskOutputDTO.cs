using Domain.Agilis.Enums;
using System;

namespace Domain.Agilis.DTOs.Task
{
    public class TaskOutputDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public string TaskNumber { get; set; }

        public EStatusTask Status { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public DateTime ReleaseDate { get; set; }

        public int IdMember { get; set; }

        public int IdSprint { get; set; }

        public bool Active { get; set; }
    }
}
