using System;
using System.ComponentModel.DataAnnotations;

namespace Domain.Agilis.DTOs.Project
{
    public class ProjectUpdateDTO
    {
        [Required(ErrorMessage = "IdProject required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "NameProject required")]
        public string Name { get; set; }

        [Required(ErrorMessage = "StarDateProject required")]
        public DateTime StartDate { get; set; }

        [Required(ErrorMessage = "EndDateProject required")]
        public DateTime EndDate { get; set; }
    }
}
