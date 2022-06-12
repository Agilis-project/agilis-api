using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Agilis.DTOs.Sprint
{
    public class SprintUpdateDTO
    {
        [Required(ErrorMessage = "IdSprint required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "NameSprint required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "SprintNumber required")]
        public string SprintNumber { get; set; }

        [Required(ErrorMessage = "StartDateSprint required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "EndDateSprint required")]
        public DateTime EndDate { get; set; }

        [Required(ErrorMessage = "IdProject required")]
        public int IdProject { get; set; }
    }
}
