using System;

namespace Domain.Agilis.DTOs.Sprint
{
    public class SprintOutputDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string SprintNumber { get; set; }

        public DateTime StartDate { get; set; }

        public DateTime EndDate { get; set; }

        public int IdProject { get; set; }

        public bool Active { get; set; }
    }
}
